using Domain;
using Domain.Entities;
using Domain.Entities.PlayerEntities;

namespace Application;

public class ContextProvider: IContextProvider
{
    private Game _game;

    public ContextProvider(Game game)
    {
        _game = game;
    }

    public IContext GetContext()
    {
        if (!_game.Player.IsAlive)
        {
            return _game;
        }
        
        var playerLocation = _game.Map.PlayerLocation;
        if (playerLocation != null)
        {
            var actions = playerLocation.GetAvailableActions();
            if (actions.Any())
            {
                return playerLocation;
            }
            var challenge = playerLocation.CurrentChallenge;
            if (challenge != null && challenge.GetAvailableActions().Any())
            {
                return challenge;                
            }
        }
        else
        {
            var actions = _game.Map.GetAvailableActions();
            if (actions.Any())
            {
                return _game.Map;
            }
        }

        return _game;
    }
}