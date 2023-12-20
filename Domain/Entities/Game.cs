using System.Net.Mime;
using Domain.Commands;
using Domain.Entities.Challenges;
using Domain.Entities.Locations;
using Domain.Entities.PlayerEntities;
using Domain.Enums;

namespace Domain.Entities;

public class Game: IContext
{
    public Game(Player player, Map map)
    {
        Player = player;
        Map = map;
        Result = GameResult.NotDefined;
        Title = "Остров загадок";
    }

    public GameResult Result { get; private set; }
    
    public Player Player { get; private set; }
    
    public Map Map { get; private set; }

    public bool IsOver => Result != GameResult.NotDefined;
    
    public string Title { get; }

    private void UpdateState()
    {
        if (Map.PlayerInLastLocation()
            && Map.PlayerLocation.Challenges.All(c => c.IsPassed)
            && Player.IsAlive)
            Result = GameResult.Passed;
    }

    public IEnumerable<ICommand> GetAvailableActions()
    {
        if (IsOver)
        {
            if (Result == GameResult.Passed)
            {
                return new ICommand[]
                {
                    new FinishCommand(),
                };
            }
        }
        return new ICommand[]
        {
            new StartGameCommand(this),
        };
    }
}