using System.Drawing;
using Domain.Commands;
using Domain.Enums;

namespace Domain.Entities.Challenges;

public abstract class Challenge : IContext
{
    private ICommand[] _defaultCommands;

    protected Challenge()
    {
        _defaultCommands = new ICommand[]
        {
            new StartChallengeCommand(this),
            new ExitCommand(),
        };
    }

    public abstract string Title { get; }

    // public string Description { get; }

    public abstract bool IsPassed { get; protected set; }

    public ChallengeState State { get; protected set; }

    // public abstract string ProgressTitle { get; protected set; }
    
    public void Start()
    {
        State = ChallengeState.InProgress;
    }

    public IEnumerable<ICommand> GetAvailableActions()
    {
        return State switch
        {
            ChallengeState.Finished => Array.Empty<ICommand>(),
            ChallengeState.NotStarted => new ICommand[]{new StartChallengeCommand(this), new ExitCommand()},
            ChallengeState.InProgress => GetProgressCommands(),
            _ => Array.Empty<ICommand>()
        };
    }

    protected abstract IEnumerable<ICommand> GetProgressCommands();
}