using System.Runtime.InteropServices.JavaScript;
using Domain.Entities.Items;
using Domain.Enums;

namespace Domain.Entities.PlayerEntities;

public class Player
{
    public List<Item> Items { get; set; }

    public List<Parameter> Parameters { get; set; }

    public bool IsAlive { get; } = true;

    public PlayerState State { get; set; }

    public IEnumerable<ICommand> GetAvailableActions()
    {
        if (IsAlive) return Array.Empty<ICommand>();

        return Array.Empty<ICommand>();
    }
}