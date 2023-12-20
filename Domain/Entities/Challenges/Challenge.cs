using System.Drawing;
using Domain.Commands;
using Domain.Enums;

namespace Domain.Entities.Challenges;

public abstract class Challenge : IContext
{
    private ICommand[] DefaultCommands;

    protected Challenge()
    {
        DefaultCommands = new ICommand[]
        {
            new StartChallengeCommand(this),
            new ExitCommand(),
        };
    }

    public string Title { get; protected set; }

    // public string Description { get; }

    public abstract bool IsPassed { get; protected set; }

    public ChallengeState State { get; protected set; }

    public abstract string ProgressTitle { get; protected set; }
    
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

    public void Execute(IReadOnlyCommand command)
    {
        // var defaultCommand = DefaultCommands.FirstOrDefault(c => c.Equals(command));
        // if (defaultCommand != null)
        //     Start();
        // else
        //     ExecuteProgressCommand(command);
    }
    
    protected abstract void ExecuteProgressCommand(IReadOnlyCommand command);

    protected abstract IEnumerable<ICommand> GetProgressCommands();
}