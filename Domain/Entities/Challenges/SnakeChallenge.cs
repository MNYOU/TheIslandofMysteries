using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Challenges
{
    public class SnakeChallenge : Challenge
    {
        public override bool IsPassed { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
        public override string ProgressTitle { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

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
