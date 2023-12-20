using System.Drawing;
using Domain.Entities.Challenges;
using Domain.Entities.Commands;

namespace Domain.Commands;

public class MoveCommand: ICommand
{
    public MoveCommand(MazeChallenge mazeChallenge, Point destination)
    {
        _mazeChallenge = mazeChallenge;
        _destination = destination;
    }

    public string Title { get; }
    public string Type { get; set; }
    public string Key { get; set; }

    private MazeChallenge _mazeChallenge;
    private readonly Point _destination;


    public string Execute()
    {
        _mazeChallenge.MovePlayer(_destination);
        // MovePlayer(_destination);
        return "Успешно";
    }
    
    private void MovePlayer(Point offset)
    {
        // var newPosition = PlayerPosition.Add(offset);
        // if (newPosition.X >= Width || newPosition.Y >= Height || newPosition.Y < 0 || newPosition.Y < 0)
        //     throw new ArgumentException();
        // if (!Maze[newPosition.Y, newPosition.X])
        //     throw new ArgumentException();
        // PlayerPosition = newPosition;
    }

}