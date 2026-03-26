using Microsoft.Extensions.DependencyInjection;

namespace ModularApp.Core
{
    public interface IAppModule
    {
        string Name { get; }

        IEnumerable<string> DependsOn { get; }

        void RegisterServices(IServiceCollection services);

        void Initialize(IServiceProvider provider);
    }
}