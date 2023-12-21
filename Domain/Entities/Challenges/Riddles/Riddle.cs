using Domain.Enums;

namespace Domain.Entities.Challenges.Riddles;

public class Riddle: Challenge
{
    public AnswerOption AnswerOptions { get; set; }

    public override string Title
    {
        get
        {
            // if (State == ChallengeState.NotStarted)
            return "Хочешь услышать загадку? Вижу, что хочешь.";
        }
    }
    public override bool IsPassed { get; protected set; }
    public  string ProgressTitle { get; protected set; }

    protected override IEnumerable<ICommand> GetProgressCommands()
    {
        throw new NotImplementedException();
    }
}