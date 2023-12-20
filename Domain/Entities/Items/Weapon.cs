using Domain.Enums;

namespace Domain.Entities.Items;

public class Weapon: Item
{
    public ItemType Type => ItemType.Weapon;

    public int Damage { get; set; }
}