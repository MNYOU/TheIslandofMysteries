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
        private readonly string name;
        public StartGameCommand(string name) : base(name)
        {
            this.name = name;
        }

        public override object Clone()
        {
            return new StartGameCommand(name);
        }

        public override string Execute(string[] args)
        {
            ///TODO: "Здесь создание игрока и старт игры";
            return "Старт";
        }
    }
}
