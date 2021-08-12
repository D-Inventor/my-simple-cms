using System.ComponentModel.DataAnnotations;

namespace Cms.Razor.Models.Options
{
    public class BackofficeUrlOptions
    {
        public const string Section = "BackofficeUrl";
        private string _basePath;

        [Required]
        public string BasePath { get => _basePath; set => _basePath = value.Trim('/'); }
    }
}
