using ConsoleApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CommandsExecutor
{
    public interface ICommandsExecutor
    {
        public List<BaseCommand> GetCommands();
        string[] GetAvailableCommandName();
        string Execute(string[] args);
    }
}
