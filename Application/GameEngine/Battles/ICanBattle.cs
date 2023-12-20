using Domain.Entities.Items;

namespace Application.GameEngine.Battles;

public interface ICanBattle
{
    public string Name { get; set; }

    public Item Weapon { get; set; }
}