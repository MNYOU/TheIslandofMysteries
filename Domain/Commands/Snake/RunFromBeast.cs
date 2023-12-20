using Domain.Entities;
using Domain.Entities.Enemies;
using Domain.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Snake
{
    public class RunFromBeastCommand : ICommand
    {
        public char Key { get; }

        public string Title => "Пытается убежать";
        private Player player;
        private Enemy enemy;
        private int distanceEnd;
        private InfoChalangeMeetingAnimals info;

        public RunFromBeastCommand(char key, InfoChalangeMeetingAnimals infoChalange)
        {
            player = infoChalange.Player;
            enemy = infoChalange.Enemy;
            Key = key;
            distanceEnd = infoChalange.DistanceEnd;
            info = infoChalange;
        }

        public void Execute()
        {
            if(info.Distance > distanceEnd)
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что за ним уже никто не гонется
                return;
            }
            var runDistance = player.GetRunDistance(enemy);
            info.Distance += runDistance;
            if(info.Distance == 0)
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что его догнали и он потерял какое то количество здоровья
            }
            else
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что он отрывается и растояние такое то.
            }
        }
    }
}
