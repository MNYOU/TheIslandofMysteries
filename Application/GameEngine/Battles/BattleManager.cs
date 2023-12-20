using Application.GameEngine.Battles;

namespace Application.GameEngine;

public class BattleManager
{
    public BattleManager(ICanBattle warriorA, ICanBattle warriorB)
    {
        WarriorA = warriorA;
        WarriorB = warriorB;
    }
    
    public ICanBattle WarriorA { get; }
    public ICanBattle WarriorB { get; }

    public ICanBattle Winner { get; private set; }
    
    public ICanBattle Loser { get; private set; }
    
    public void Battle()
    {
        
    }
}