using Domain.Commands;
using Domain.Commands.Maps;
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

    public void MovePlayerToNextLocation()
    {
        var index = Locations.IndexOf(PlayerLocation);
        if (index == Locations.Count - 1)
            throw new InvalidOperationException();
        PlayerLocation = Locations[index + 1];
    }

    public string Title { get; }

    public IEnumerable<ICommand> GetAvailableActions()
    {
        var index = Locations.IndexOf(PlayerLocation);
        if (index == Locations.Count - 1)
        {
            return new ICommand[0];
        }

        var nextLoc = Locations[index + 1];
        return new ICommand[] { new GoToNextCommand(this, nextLoc) };
    }

    public void Execute(IReadOnlyCommand command)
    {
        return;
        if (command.Key == "m")
        {
            MovePlayerToNextLocation();
        }
        else
            throw new ArgumentException();
    }

    public bool PlayerInLastLocation()
    {
        return PlayerLocation == Locations.Last();
    }
}