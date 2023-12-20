using Domain.Entities.Commands;
using Domain.Entities.Locations;
using Domain.Enums;

namespace Domain.Entities;

public class Map: IContext
{
    public Map()
    {
        Title = "Длинный путь предстоит страннику, вставшему на путь к сокровищу";
    }
    
    public List<Location> Locations { get; set; }
    
    public Location PlayerLocation { get; private set; }

    private void MovePlayer()
    {
        var index = Locations.IndexOf(PlayerLocation);
        if (index == Locations.Count - 1)
            throw new InvalidOperationException();
        PlayerLocation = Locations[index + 1];
    }

    public string Title { get; }

    public IEnumerable<IReadOnlyCommand> GetAvailableActions()
    {
        var index = Locations.IndexOf(PlayerLocation);
        if (index == Locations.Count - 1)
        {
            return new IReadOnlyCommand[0];
        }

        var nextLoc = Locations[index + 1];
        return new IReadOnlyCommand[] { new BaseCommand("m", $"Двигаться к точке: {nextLoc.Description}") };
    }

    public void Execute(IReadOnlyCommand command)
    {
        if (command.Key == "m")
        {
            MovePlayer();
        }
        else
            throw new ArgumentException();
    }

    public bool PlayerInLastLocation()
    {
        return PlayerLocation == Locations.Last();
    }
}