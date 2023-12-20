using Domain.Entities.Enemies;
using Domain.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InfoChalangeMeetingAnimals
    {
        public Player Player { get; }
        public Enemy Enemy { get; }
        public int Distance { get; set; }
        public int DistanceEnd { get; }
        public InfoChalangeMeetingAnimals(Player player, Enemy enemy, int distance, int distanceEnd)
        {
            Player = player;
            Enemy = enemy;
            Distance = distance;
            DistanceEnd = distanceEnd;
        }
    }
}
