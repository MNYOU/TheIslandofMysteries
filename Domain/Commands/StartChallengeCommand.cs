using Domain.Entities.Challenges;

namespace Domain.Commands;

public class StartChallengeCommand: IReadOnlyCommand
{
    public Guid Id { get; set; }

    public string Title => "Начать испытание";
    public string Key { get; set; }

    private Challenge challenge;

    public StartChallengeCommand()
    {
        Key = "1.";
        // this.challenge = challenge;
    }

    // public void Execute()
    // {
    //     challenge.Start();
    // }
}