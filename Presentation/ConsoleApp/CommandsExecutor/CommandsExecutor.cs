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
        private readonly TextWriter writer;
        private readonly TextReader reader;
        private readonly List<BaseCommand> commands = new List<BaseCommand>();

        public CommandsExecutor(TextWriter writer, TextReader reader)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Register(BaseCommand command)
        {
            commands.Add(command);
        }

        public string[] GetAvailableCommandName()
        {
            return commands.Select(c => c.Name).ToArray();
        }

        public BaseCommand FindCommandByName(string name)
        {
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public void Execute(string[] args)
        {
            if (args[0].Length == 0)
            {
                Console.WriteLine("Please specify <command> as the first command line argument");
                return;
            }

            var commandName = args[0];
            var cmd = FindCommandByName(commandName);
            if (cmd == null)
                writer.WriteLine("Sorry. Unknown command {0}", commandName);
            else
                cmd.Execute(args, writer, reader);
        }
    }
}
