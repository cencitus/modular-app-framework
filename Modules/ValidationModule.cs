using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ModularApp.Core;

namespace ModularApp.Modules
{
    public class ValidationModule : IAppModule
    {
        public string Name => "Validation";

        public IEnumerable<string> DependsOn => new[] { "Core" };

        public void RegisterServices(IServiceCollection services)
        {
        }

        public void Initialize(IServiceProvider provider)
        {
            Console.WriteLine("Модуль проверки данных активирован");
        }
    }
}