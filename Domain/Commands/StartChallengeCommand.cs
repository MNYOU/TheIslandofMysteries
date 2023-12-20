using Domain.Entities.Challenges;

namespace Domain.Commands;

public class StartChallengeCommand: ICommand
{
    private readonly Challenge _challenge;

    public StartChallengeCommand(Challenge challenge)
    {
        this._challenge = challenge;
    }

    public char Key => 's';
    public string Title => "Начать испытание";
    
    public void Execute()
    {
       _challenge.Start();
    }
}