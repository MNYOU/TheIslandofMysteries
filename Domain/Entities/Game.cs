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

        UpdateContext();
        Result = GameResult.NotDefined;

        Title = "Остров загадок";
    }

    public GameResult Result { get; private set; }
    
    public Player Player { get; private set; }
    
    public Map Map { get; private set; }

    public bool IsOver => Result != GameResult.NotDefined;

    private IContext context;

    public string Title { get; }

    public IContext GetContext()
    {
        UpdateState();
        UpdateContext();
        return context;
    }

    private void UpdateState()
    {
        var pLoc = Map.PlayerLocation;
        if (Map.PlayerInLastLocation()
            && Map.PlayerLocation.Challenges.All(c => c.IsPassed)
            && Player.IsAlive)
            Result = GameResult.Passed;
    }

    public IEnumerable<IReadOnlyCommand> GetAvailableActions()
    {
        UpdateContext();
        if (context == this)
        {
            if (IsOver)
            {
                if (Result == GameResult.Passed)
                {
                    return new IReadOnlyCommand[]
                    {
                        new FinishCommand(),
                    };
                }
            }
            return new IReadOnlyCommand[]
            {
                new StartGameCommand(),
            };
        }
        return context.GetAvailableActions();
    }

    public void Execute(IReadOnlyCommand command)
    {
        if (GetAvailableActions().All(c => c.Key != command.Key))
            throw new ArgumentException();
        
        ExecuteAction(command);
    }
    
    private void ExecuteAction(IReadOnlyCommand command)
    {
        UpdateContext();
        if (context == this)
        {
            if (command.Key[0] == 'n')
            {
                
            }
            else if (command.Key[0] == 'e')
            {
                Environment.Exit(1);
            }

            return;
        }
        else
        {
            context.Execute(command);
        }
    }

    private void UpdateGameResult()
    {
        // может логику перенести в поле?
    }

    private void UpdateContext()
    {
        // попробовать linkedList?
        // начинать с конца

        if (!Player.IsAlive)
        {
            context = this;
            return;                
        }

        var actions = Map.GetAvailableActions();
        if (actions.Any())
        {
            context = Map;
            return;
        }

        var playerLocation = Map.PlayerLocation;
        if (playerLocation != null)
        {
            actions = playerLocation.GetAvailableActions();
            if (actions.Any())
            {
                context = playerLocation;
                return;
            }
            var challenge = playerLocation.CurrentChallenge;
            if (challenge != null && challenge.GetAvailableActions().Any())
            {
                context = challenge;
                return;                
            }
        }
        else
        {
            context = Map;
            return;
        }


        context = this;
    }
}