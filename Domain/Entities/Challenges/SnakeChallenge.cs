using Domain.Commands;
using Domain.Commands.Snake;
using Domain.Entities.Enemies;
using Domain.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities.Challenges
{
    public class SnakeChallenge : Challenge
    {
        private Player player;
        private SnakeEnemy snake;
        private int distance;
        private int endDistance;
        private InfoChalangeMeetingAnimals infoChalange;

        public override bool IsPassed { get; protected set; }

        public override string Title => "Испытание змея";

        public SnakeChallenge(Player player, SnakeEnemy snake, int distance, int endDistance) 
        { 
            this.player = player;
            this.snake = snake;
            this.distance = distance;
            this.endDistance = endDistance;
            infoChalange = new InfoChalangeMeetingAnimals(player, snake, distance, endDistance);
        }

        protected override void ExecuteProgressCommand(IReadOnlyCommand command)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<ICommand> GetProgressCommands()
        {
            if (!player.IsAlive || !snake.IsAlive || distance >= endDistance)
            {
                return Enumerable.Empty<ICommand>();
            }
            var commands = new List<ICommand>();
            if(player.CheckCanRun())
            {
                commands.Add(new RunFromBeastCommand('r', infoChalange));
            }
            if(distance > 0)
            {
                commands.Add(new GetCloseEnemy('e', infoChalange));
            }
            if(distance == 0)
            {
                commands.Add(new FightCommand('a', infoChalange));
            }
            return commands;
        }
    }
}
