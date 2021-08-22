using Cms.Core;
using Cms.Core.Providers;
using Cms.Pipeline;
using Cms.Website.Models;
using Cms.Website.Providers;
using Cms.Website.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cms.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<RegisterStaticDocumentsService>();
            services.AddScoped<IDocumentProvider<StaticModelExample>, StaticModelExampleProvider>();

            services.AddControllersWithViews();
            // Add the cms to controllers and views if you want a complete cms experience

            // Always add the core services so you can read and write content to the cms
            services.AddCmsCore();

            // Add the pipeline services if you want to bind content to requests and controllers
            services.AddCmsPipeline();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // add UseCmsDocument before routing to add a document to the httpcontext that matches the incoming request
            app.UseCmsDocument();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                // map cms documents to specialised cms controllers. This requires a call to UseCmsDocument!
                endpoints.MapCmsDocumentControllerRoute();
            });
        }
    }
}
