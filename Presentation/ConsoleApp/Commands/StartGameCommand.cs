using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.Commands
{
    public class StartGameCommand : BaseCommand
    {
        public StartGameCommand(string name) : base(name)
        { }

        public override void Execute(string[] args, TextWriter writer, TextReader reader)
        {
            writer.WriteLine("Здесь создание игрока и старт игры");
        }
    }
}
