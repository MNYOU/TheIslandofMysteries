using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Challenges
{
    public class SnakeChallenge : Challenge
    {
        private Random rnd;
        private int levelDangerSnake;
        public override bool IsPassed { get; protected set; }
        public override string ProgressTitle { get; protected set; }
        public SnakeChallenge() 
        { 
            rnd = new Random();
            levelDangerSnake = rnd.Next(0, 10);

        }

        protected override void ExecuteProgressCommand(IReadOnlyCommand command)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<ICommand> GetProgressCommands()
        {
            throw new NotImplementedException();
        } 
    }
}
