using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularApp.Core
{
    public class ModuleLoadException : Exception
    {
        public ModuleLoadException(string message) : base(message)
        {
        }
    }
}