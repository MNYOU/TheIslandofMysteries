using Domain.Entities.Enemies;
using Domain.Entities.PlayerEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class GoBackEnemy : ICommand
    {
        public char Key { get; }

        public string Title => "Идти обратно к врагу";
        private Player player;
        private Enemy enemy;
        private int distanceEnd;
        private InfoChalangeMeetingAnimals info;

        public GoBackEnemy(char key, InfoChalangeMeetingAnimals infoChalange)
        {
            player = infoChalange.Player;
            enemy = infoChalange.Enemy;
            Key = key;
            distanceEnd = infoChalange.DistanceEnd;
            info = infoChalange;
        }

        public void Execute()
        {
            if (info.Distance > distanceEnd)
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что за ним уже никто не гонется
                return;
            }
            var playerValue = player.Parameters[ParameterType.Speed].Value;
            var enemyValue = enemy.Parameters[ParameterTypeEnemies.Speed].Value;
            if (playerValue + enemyValue <= info.Distance)
                info.Distance = 0;
            else
                info.Distance -= (playerValue + enemyValue);
            if (info.Distance <= 0)
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что он вернулся к врагу. на следующем хоже будет битва
            }
            else
            {
                ///TODO: переделать под string, и возвращать текущее состояние того, что осталось столько то растояния
            }
        }
    }
}
