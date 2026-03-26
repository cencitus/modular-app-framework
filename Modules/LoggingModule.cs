using Microsoft.Extensions.DependencyInjection;
using ModularApp.Core;
using ModularApp.Services;

namespace ModularApp.Modules
{
    public class LoggingModule : IAppModule
    {
        public string Name => "Logging";

        public IEnumerable<string> DependsOn => new[] { "Core" };

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, ConsoleLogger>();
        }

        public void Initialize(IServiceProvider provider)
        {
            var logger = provider.GetRequiredService<ILogger>();

            logger.Log("DI контейнер внедрил ILogger");
            logger.Log("Модуль логирования запущен");
        }
    }
}