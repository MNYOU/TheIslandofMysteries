namespace Domain.Entities.Challenges.Riddles;

public class Riddle: Challenge
{
    public AnswerOption AnswerOptions { get; set; }
    
    public override bool IsPassed { get; protected set; }
    public override string ProgressTitle { get; protected set; }

    protected override void ExecuteProgressCommand(IReadOnlyCommand command)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<ICommand> GetProgressCommands()
    {
        throw new NotImplementedException();
    }
}