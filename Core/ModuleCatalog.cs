using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace ModularApp.Core
{
    public class ModuleCatalog
    {
        public static List<IAppModule> LoadModules(List<string> moduleNames)
        {
            var moduleTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IAppModule).IsAssignableFrom(t) && !t.IsInterface);

            var modules = new Dictionary<string, IAppModule>();

            foreach (var type in moduleTypes)
            {
                var module = (IAppModule)Activator.CreateInstance(type)!;
                modules[module.Name] = module;
            }

            // Проверка отсутствующего модуля
            foreach (var name in moduleNames)
            {
                if (!modules.ContainsKey(name))
                {
                    throw new ModuleLoadException($"Модуль '{name}' не найден");
                }
            }

            // Строим порядок запуска
            var result = new List<IAppModule>();
            var visited = new HashSet<string>();
            var visiting = new HashSet<string>();

            void Visit(string name)
            {
                if (visited.Contains(name))
                    return;

                if (visiting.Contains(name))
                    throw new ModuleLoadException("Обнаружена циклическая зависимость модулей");

                visiting.Add(name);

                var module = modules[name];

                foreach (var dep in module.DependsOn)
                {
                    if (!modules.ContainsKey(dep))
                        throw new ModuleLoadException($"Модуль '{name}' зависит от отсутствующего модуля '{dep}'");

                    Visit(dep);
                }

                visiting.Remove(name);
                visited.Add(name);
                result.Add(module);
            }

            foreach (var name in moduleNames)
            {
                Visit(name);
            }

            return result;
        }
    }
}