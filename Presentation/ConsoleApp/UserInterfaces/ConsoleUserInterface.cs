using ConsoleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.UserInterfaces
{
    internal class ConsoleUserInterface
    {
        private readonly BaseController controller;

        public ConsoleUserInterface(BaseController controller)
        {
            this.controller = controller;
        }

        public void HandleUserInput(string userInput)
        {
            if (userInput == "start")
            {
                controller.ShowStartMeccage();
            }
            //... Другая обработка событий 
        }
    }
}