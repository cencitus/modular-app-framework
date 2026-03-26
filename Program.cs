using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ModularApp.Core;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var moduleNames = config.GetSection("Modules").Get<List<string>>();

// Ранее загрузка модулей выполнялась напрямую в Program.cs. Для улучшения архитектуры и соответствия заданию
// эта логика была вынесена в отдельный класс ModuleCatalog.

/*
var moduleTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(IAppModule).IsAssignableFrom(t) && !t.IsInterface);

var modules = new List<IAppModule>();

foreach (var type in moduleTypes)
{
    var module = (IAppModule)Activator.CreateInstance(type)!;

    if (moduleNames.Contains(module.Name))
    {
        modules.Add(module);
    }
}
*/

var modules = ModuleCatalog.LoadModules(moduleNames);

var services = new ServiceCollection();

foreach (var module in modules)
{
    module.RegisterServices(services);
}

var provider = services.BuildServiceProvider();

foreach (var module in modules)
{
    module.Initialize(provider);
}