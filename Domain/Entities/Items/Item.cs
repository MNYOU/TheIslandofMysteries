using Domain.Enums;

namespace Domain.Entities.Items;

public class Item
{
    public string Name { get; }

    public string Description { get; }

    public ItemType Type { get; }
}