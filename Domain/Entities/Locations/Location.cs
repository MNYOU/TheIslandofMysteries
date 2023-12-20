using Domain.Entities.Challenges;
using Domain.Entities.Commands;
using Domain.Enums;

namespace Domain.Entities.Locations;

public abstract class Location : IContext
{
    protected Location(string description, List<Challenge> challenges)
    {
        Description = description;
        Challenges = challenges;
        CurrentChallenge = Challenges.FirstOrDefault();

        Title = "Густой и страшный еловый лес. Вас охватывает дрожь...";
    }

    public string Description { get; }

    public List<Challenge> Challenges { get; }

    public Challenge? CurrentChallenge { get; protected set; }

    public virtual void GoToNextChallenge()
    {
        if (CurrentChallenge is { IsPassed: true })
        {
            var index = Challenges.IndexOf(CurrentChallenge);
            if (index == Challenges.Count + 1)
                CurrentChallenge = null;
        }
    }

    public string Title { get; }

    public IEnumerable<IReadOnlyCommand> GetAvailableActions()
    {
        if (CurrentChallenge == null || CurrentChallenge.State == ChallengeState.Finished && CurrentChallenge != Challenges.Last())
            return new IReadOnlyCommand[]
            {
                new BaseCommand("n", "Перейти к следующему испытанию."),
            };
        return new IReadOnlyCommand[0];
    }

    public void Execute(IReadOnlyCommand command)
    {
        if (command.Key == "n")
        {
            if (CurrentChallenge != null && CurrentChallenge.State != ChallengeState.Finished)
                throw new InvalidOperationException();
            GoToNextChallenge();
            // var index = Challenges.IndexOf(CurrentChallenge);
            // if (index == Challenges.Count + 1)
            // CurrentChallenge = null;
        }
        else
            throw new NotImplementedException();
    }
}