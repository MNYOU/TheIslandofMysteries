using ConsoleApp.CommandsExecutor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.UserInterfaces
{
    internal class ConsoleUserInterface
    {
        private readonly TextWriter writer;
        private readonly TextReader reader;
        private readonly ICommandsExecutor executor;

        public ConsoleUserInterface(TextReader reader, TextWriter writer, ICommandsExecutor executor)
        {
            this.writer = writer;
            this.reader = reader;
            this.executor = executor;
        }

        public void StartMessage(string startText)
        {
            writer.WriteLine(startText);
            ViewAllCommands();
        }

        public void StopMessage(string endText) 
        {
            writer.WriteLine(endText);
        }

        public string GetCommandName()
        {
            return reader.ReadLine();
        }

        public void ViewAllCommands()
        {
            writer.WriteLine($"Введите в следующей строке одну из кодманд: {string.Join(", ", executor.GetCommands())}");
        }

        public void HandleUserInput(string userInput)
        {
            if (userInput == null || userInput == "exit")
            {
                StopMessage(userInput);
                return;
            }
            if (userInput == "start")
            {
                StartMessage(userInput);
            }
            var command = new[] { userInput };
            var resultExecute = executor.Execute(command);
            //... Другая обработка событий 
        }
    }
}