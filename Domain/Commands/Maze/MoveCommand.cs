using System.Drawing;
using Domain.Entities.Challenges;
using Infrastructure.Extensions;

namespace Domain.Commands.Maze;

public class MoveCommand: ICommand
{
    private readonly MazeChallenge _mazeChallenge;
    private readonly Point _destination;

    public MoveCommand(MazeChallenge mazeChallenge, Point destination, char key)
    {
        Key = key;
        _mazeChallenge = mazeChallenge;
        _destination = destination;
        Title = $"Двигаться в ({destination.X};{destination.Y}).";
    }

    public char Key { get; }

    public string Title { get; }

    public void Execute() => MovePlayer(_destination);
    
    private void MovePlayer(Point offset)
    {
        var newPosition = _mazeChallenge.PlayerPosition.Add(offset);
        _mazeChallenge.PlayerPosition = newPosition;
    }
}