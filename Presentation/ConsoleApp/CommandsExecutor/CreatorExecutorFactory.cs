using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CommandsExecutor
{
    public abstract class CreatorExecutorFactory
    {
        public abstract ICommandsExecutor CreateExecutor();
    }
}
