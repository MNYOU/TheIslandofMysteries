namespace Domain.Entities.Challenges;

public class Storm: Challenge
{
    public int Level { get; set; }

    public override string Title { get; }
    public override bool IsPassed { get; protected set; }
    public  string ProgressTitle { get; protected set; }

    protected override IEnumerable<ICommand> GetProgressCommands()
    {
        throw new NotImplementedException();
    }
}