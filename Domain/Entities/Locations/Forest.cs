using Domain.Entities.Challenges;

namespace Domain.Entities.Locations;

public class Forest: Location
{
    public Forest(List<Challenge> challenges) : base("Северный и холодный лес. Тут умерли многие ваши враги.", challenges)
    {
        
    }
}