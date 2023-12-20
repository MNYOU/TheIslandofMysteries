using Domain.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enemies
{
    public class SnakeEnemy : Enemy
    {
        public override string Name { get; }
        public override bool IsAlive { get; set; }

        public SnakeEnemy(string name)
        {
            Name = name;
            IsAlive = true;
        }

        public void TakeDamage(int damage)
        {
            Parameters[ParameterTypeEnemies.Health].Value -= damage;
            var value = Parameters[ParameterTypeEnemies.Health].Value;
            if (value <= 0)
            {
                IsAlive = false;
            }
        }

        public int GetDamagForPlayer()
        {
            return Parameters[ParameterTypeEnemies.Strength].Value;
        }
    }
}
