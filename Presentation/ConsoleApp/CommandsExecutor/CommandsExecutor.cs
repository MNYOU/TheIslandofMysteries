using ConsoleApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CommandsExecutor
{
    public class CommandsExecutor : ICommandsExecutor
    {
        private readonly List<BaseCommand> commands;

        public CommandsExecutor()
        {
            commands = new List<BaseCommand>();
        }

        public void Register(BaseCommand command)
        {
            commands.Add(command);
        }

        public List<BaseCommand> GetCommands()
        {
            return commands.Select(item => (BaseCommand)item.Clone()).ToList();
        }

        public string[] GetAvailableCommandName()
        {
            return commands.Select(c => c.Name).ToArray();
        }

        public BaseCommand FindCommandByName(string name)
        {
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public string Execute(string[] args)
        {
            if (args[0].Length == 0)
            {
                throw new ArgumentException("Please specify <command> as the first command line argument");
            }

            var commandName = args[0];
            var cmd = FindCommandByName(commandName);
            if (cmd == null)
                throw new Exception($"Sorry. Unknown command {commandName}");
            return cmd.Execute(args);
        }
    }
}
