using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CommandsExecutor
{
    public interface ICommandsExecutor
    {
        string[] GetAvailableCommandName();
        void Execute(string[] args);
    }
}
