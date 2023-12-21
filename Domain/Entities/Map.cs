using Domain.Commands;
using Domain.Commands.Maps;
using Domain.Entities.Locations;
using Domain.Enums;

namespace Domain.Entities;

public class Map: IContext
{
    public List<Location> Locations { get; set; }
    
    public Location PlayerLocation { get; private set; }

    public string Title { get; } = "Длинный путь предстоит страннику, вставшему на путь к сокровищу";

    public void MovePlayerToNextLocation()
    {
        var index = Locations.IndexOf(PlayerLocation);
        if (index == Locations.Count - 1)
            throw new InvalidOperationException();
        PlayerLocation = Locations[index + 1];
    }

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

    public bool PlayerInLastLocation()
    {
        return PlayerLocation == Locations.Last();
    }
}