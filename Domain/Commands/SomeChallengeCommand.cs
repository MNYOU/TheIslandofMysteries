using Domain.Entities.Challenges;

namespace Domain;

public class SomeChallengeCommand
{
    private readonly Challenge challenge;
    
    public string Title { get; }
    public void Execute()
    {
        // challenge.
        throw new NotImplementedException();
    }
}