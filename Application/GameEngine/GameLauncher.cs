using Domain.Entities;
using Domain.Entities.Challenges;
using Domain.Entities.Items;
using Domain.Entities.Locations;
using Domain.Entities.PlayerEntities;

namespace Application.GameEngine;

public class GameLauncher
{
    private Game game;

    public Game Start()
    {
        var player = InitializePlayer();
        var map = InitializeMap();

        var game = new Game(player, map);
        return game;
    }

    public Game LoadFromFile(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveProgress(string path)
    {
        throw new NotImplementedException();
    }

    private Game Initialize()
    {
        throw new NotImplementedException();
    }

    // Initialize
    private Player InitializePlayer()
    {
        // генерация р.н. предметов, характеристик
        var items = new List<Item>();
        var parameters = new Dictionary<ParameterType, Parameter>()
        {
            { ParameterType.Health, new Parameter(ParameterType.Health, 50, 100) },
            { ParameterType.Agility,  new Parameter(ParameterType.Agility, 50, 100) },
            { ParameterType.Luck, new Parameter(ParameterType.Luck, 50, 100) },
            { ParameterType.Strength, new Parameter(ParameterType.Strength, 50, 100) },
            { ParameterType.Speed, new Parameter(ParameterType.Speed, 50, 100) },
        };
        var player = new Player()
        {
            Parameters = parameters,
            Items = items,
        };
        return player;
    }

    private Map InitializeMap()
    {
        var maze =
            "  ###\n" +
            "# # #\n" +
            "#   #\n" +
            "## ##\n" +
            "#    ";
        // maze = "";
        var mazeChallenge = new MazeChallenge(maze);
        var location = new Forest(new List<Challenge>() { mazeChallenge });
        return new Map() { Locations = new List<Location>() { location } };
    }
}