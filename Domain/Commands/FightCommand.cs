using Domain.Entities;
using Domain.Entities.Enemies;
using Domain.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class FightCommand : ICommand
    {
        public char Key { get; }
        public string Title => "Битва идет";

        private Player player;
        private Enemy enemy;

        public FightCommand(char key, InfoChalangeMeetingAnimals infoChalange)
        {
            player = infoChalange.Player;
            enemy = infoChalange.Enemy;
            Key = key;
        }

        public void Execute()
        {
            Batle();
            if(!player.CheckHealth())
            {
                ///TODO: Игра закончена((
            }
            else
            {
                ///TODO: Вы получили урон. Сейчас у вас такой то уровень жизни.
            }
        }

        private void Batle()
        {
            var playerDamage = player.Parameters[ParameterType.Strength].Value;
            var enemyDamage = enemy.Parameters[ParameterTypeEnemies.Strength].Value;
            var enemyHealth = enemy.Parameters[ParameterTypeEnemies.Health].Value -= playerDamage;
            if (enemyHealth > 0)
                player.Parameters[ParameterType.Health].Value -= enemyDamage;
        }
    }
}
