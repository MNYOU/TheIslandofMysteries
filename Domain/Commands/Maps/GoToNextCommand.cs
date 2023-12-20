using Domain.Entities;
using Domain.Entities.Locations;

namespace Domain.Commands.Maps;

public class GoToNextCommand: BaseCommand, ICommand
{
    private readonly Map _map;

    public GoToNextCommand(Map map, Location nextLocation) : base('n', $"Двигаться к точке: {nextLocation.Description}")
    {
        _map = map;
    }

    public override void Execute()
    {
        _map.MovePlayerToNextLocation();
    }
}