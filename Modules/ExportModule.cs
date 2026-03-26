using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using ModularApp.Core;

namespace ModularApp.Modules
{
    public class ExportModule : IAppModule
    {
        public string Name => "Export";

        public IEnumerable<string> DependsOn => new[] { "Validation" };

        public void RegisterServices(IServiceCollection services)
        {
        }

        public void Initialize(IServiceProvider provider)
        {
            Console.WriteLine("Модуль экспорта готов");
        }
    }
}