using System.Drawing;

namespace Domain.Entities.Commands;

public interface IMazeCommand: IReadOnlyCommand
{
    public Point Destination { get; set; }
}