using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using Domain.Entities.Enemies;
using Domain.Entities.Items;
using Domain.Enums;

namespace Domain.Entities.PlayerEntities;

public class Player
{
    public List<Item> Items { get; set; }

    public Dictionary<ParameterType, Parameter> Parameters { get; set; }

    public bool IsAlive { get; set; }

    public PlayerState State { get; set; }

    public IEnumerable<ICommand> GetAvailableActions()
    {
        if (IsAlive) 
            return Array.Empty<ICommand>();

        return Array.Empty<ICommand>();
    }

    public bool CheckCanRun()
    {
        return Parameters[ParameterType.Health].Value > 50;
    }

    public bool CheckHealth()
    {
        IsAlive = Parameters[ParameterType.Health].Value > 0;
        return IsAlive;
    }

    public int GetRunDistance(Enemy enemy)
    {
        var playerValue = Parameters[ParameterType.Speed].Value;
        var enemyValue = enemy.Parameters[ParameterTypeEnemies.Speed].Value;
        if (playerValue > enemyValue)
            return playerValue - enemyValue;
        return 0;
    }
    public void TakeDamage(int damage)
    {
        Parameters[ParameterType.Health].Value -= damage;
        var value = Parameters[ParameterType.Health].Value;
        if (value <= 0)
        {
            IsAlive = false;
        }
    }

    public int GetDamagForEnemy()
    {
        return Parameters[ParameterType.Strength].Value;
        var playerLuckValue = Parameters[ParameterType.Luck].Value;
        var playerUnluckValue = Parameters[ParameterType.Luck].MaxValue - playerLuckValue;

        return rndNumber == 0 ? playerStrengthValue - playerUnluckValue : playerStrengthValue + playerLuckValue;
    }
}