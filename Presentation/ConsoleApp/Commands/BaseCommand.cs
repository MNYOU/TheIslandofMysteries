using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Commands
{
    public abstract class BaseCommand
    {
        protected BaseCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract void Execute(string[] args, TextWriter writer, TextReader reader);
    }
}
