using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Commands
{
    public abstract class BaseCommand : ICloneable
    {
        protected BaseCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract object Clone();

        public abstract string Execute(string[] args);
    }
}
