using Microsoft.Extensions.DependencyInjection;
using ModularApp.Core;

public class CoreModule : IAppModule
{
    public string Name => "Core";

    public IEnumerable<string> DependsOn => new string[] { };
    // Для проверки циклического
    //public IEnumerable<string> DependsOn => new[] { "Logging" };
    public void RegisterServices(IServiceCollection services)
    {
    }

    public void Initialize(IServiceProvider provider)
    {
        Console.WriteLine("Модуль Core инициализирован");
    }
}