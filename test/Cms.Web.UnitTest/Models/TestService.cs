namespace Cms.Core.UnitTest.Models
{
    public class TestService : IGenericTestService<int>
    { }

    public interface ITestService
    { }

    public interface IGenericTestService<T> : ITestService
    { }

    public interface IAnotherTestService
    { }
}
