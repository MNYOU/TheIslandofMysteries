using System.Drawing;
using System.Text;
using Domain.Commands;
using Domain.Commands.Maze;
using Domain.Enums;
using Infrastructure.Extensions;

namespace Domain.Entities.Challenges;

public class MazeChallenge : Challenge
{
    private Point _playerPosition;

    public MazeChallenge(string stringMaze)
    {
        Maze = MapMazeFromString(stringMaze);
        var width = Maze.GetLength(0);
        var height = Maze.GetLength(1);
        if (width < 2 || height < 2)
            throw new ArgumentException();
        Width = width;
        Height = height;
    }
    
    private readonly Dictionary<Point, char> _directions = new()
    {
        [new Point(0, -1)] = 'u',
        [new Point(-1, 0)] = 'l',
        [new Point(0, 1)] = 'd',
        [new Point(1, 0)] = 'r',
    };

    private bool[,] Maze { get; }

    public int Width { get; }

    public int Height { get; }
    
    public override bool IsPassed { get; protected set; }

    public override string Title
    {
        get
        {
            if (State == ChallengeState.NotStarted)
                return "Говорят, у лабиринта нет выхода. Ещё никому не удавалось сбежать из него!";
            return GetProgressTitle();
        }
        
    }


    public Point PlayerPosition
    {
        get => _playerPosition;
        set
        {
            if (value.X < 0 || value.X >= Width || value.Y < 0 || value.Y >= Height)
                throw new ArgumentException();
            if (!Maze[value.Y, value.X])
                throw new ArgumentException();
            _playerPosition = value;
            UpdateState();
        }
    }
    
    private string GetProgressTitle()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Текущее состояние лабиринта: ");
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                if (PlayerPosition == new Point(j, i))
                    builder.Append('.');
                else
                    builder.Append(Maze[i, j] ? ' ' : '#');
            }

            builder.Append('\n');
        }

        return builder.ToString();
    }

    protected override IEnumerable<ICommand> GetProgressCommands()
    {
        return GetPossibleMoves()
            .Select(p => new MoveCommand(this, p, _directions[p]));
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