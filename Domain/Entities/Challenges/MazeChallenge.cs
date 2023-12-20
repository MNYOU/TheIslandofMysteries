using System.Drawing;
using System.Text;
using Domain.Commands;
using Domain.Entities.Commands;
using Domain.Enums;
using Infrastructure.Extensions;

namespace Domain.Entities.Challenges;

public class MazeChallenge : Challenge
{
    private IEnumerable<IMazeCommand> commands;
    
    public MazeChallenge(string stringMaze)
    {
        Maze = MapMazeFromString(stringMaze);
        var width = Maze.GetLength(0);
        var height = Maze.GetLength(1);
        if (width < 2 || height < 2)
            throw new ArgumentException();
        Width = width;
        Height = height;

        GetProgressCommands();
        UpdateTitle();
    }

    public bool[,] Maze { get; }

    private Dictionary<Point, string> directions;

    public int Width { get; }

    public int Height { get; }

    public Point PlayerPosition { get; private set; }


    public override bool IsPassed { get; protected set; }
    public override string ProgressTitle { get; protected set; }

    protected override void ExecuteProgressCommand(IReadOnlyCommand command)
    {
        if (commands.FirstOrDefault(x => x.Key == command.Key) is MazeCommand mazeCommand)
        {
            MovePlayer(mazeCommand.Destination);
            UpdateState();
            UpdateTitle();
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private void UpdateTitle()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Текущее состояние лабиринта: ");
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                var c = Maze[i, j];
                if (PlayerPosition == new Point(j, i))
                    builder.Append('.');
                else
                    builder.Append(c ? ' ' : '#');
            }

            builder.Append('\n');

            // builder[2] = 'f';
        }

        Title = builder.ToString();
    }

    protected override IEnumerable<IReadOnlyCommand> GetProgressCommands()
    {
        var d = new Dictionary<Point, string>
        {
            [new Point(0, -1)] = "u",
            [new Point(-1, 0)] = "l",
            [new Point(0, 1)] = "d",
            [new Point(1, 0)] = "r",
        };
        var moves = GetPossibleMoves();
        commands = moves
            .Select(p => new MazeCommand($"Двигаться в позицию ({p.X};{p.Y})", p, d[p]));

        return commands;
    }

    private void UpdateState()
    {
        if (State == ChallengeState.NotStarted)
            State = ChallengeState.InProgress;

        if (PlayerPosition == new Point(Width - 1, Height - 1))
        {
            IsPassed = true;
            State = ChallengeState.Finished;
        }
    }

    public void MovePlayer(Point offset)
    {
        var newPosition = PlayerPosition.Add(offset);
        if (newPosition.X >= Width || newPosition.Y >= Height || newPosition.Y < 0 || newPosition.Y < 0)
            throw new ArgumentException();
        if (!Maze[newPosition.Y, newPosition.X])
            throw new ArgumentException();
        PlayerPosition = newPosition;
    }

    private List<Point> GetPossibleMoves()
    {
        var neighbors = new List<Point>();
        for (var i = PlayerPosition.Y - 1; i < PlayerPosition.Y + 2; i++)
        {
            for (var j = PlayerPosition.X - 1; j < PlayerPosition.X + 2; j++)
            {
                if (i < 0 || i >= Height || j < 0 || j >= Width)
                    continue;
                if (Math.Abs(PlayerPosition.Y - i) + Math.Abs(PlayerPosition.X - j) != 1) continue;
                if (Maze[i, j])
                    neighbors.Add(new Point(j - PlayerPosition.X, i - PlayerPosition.Y));
            }
        }

        return neighbors;
    }

    public static bool[,] MapMazeFromString(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException();
        var rows = s.Split('\n');
        var maze = new bool[rows.Length, rows.First().Length];

        for (var i = 0; i < rows.Length; i++)
        {
            for (var j = 0; j < rows[i].Length; j++)
            {
                maze[i, j] = rows[i][j] == ' ';
            }
        }

        return maze;
    }
}