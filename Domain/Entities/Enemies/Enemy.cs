using Domain.Entities.Items;
using Domain.Entities.PlayerEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enemies
{
    public abstract class Enemy
    {
        public abstract string Name { get; }
        public Dictionary<ParameterTypeEnemies, ParameterEnemies> Parameters { get; set; }

        public abstract bool IsAlive { get; set; }
    }
}
