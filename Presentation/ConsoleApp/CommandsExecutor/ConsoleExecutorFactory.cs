using ConsoleApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CommandsExecutor
{
    public class ConsoleExecutorFactory : CreatorExecutorFactory
    {
        public override ICommandsExecutor CreateExecutor()
        {
            var executor = new CommandsExecutor();
            executor.Register(new StartGameCommand("start"));
            return executor;
        }
    }
}
