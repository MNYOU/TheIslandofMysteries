using System.Drawing;

namespace Domain.Entities.Commands;

public class MazeCommand: IMazeCommand
{
    public Guid Id { get; set; }
    public string Title { get; }
    public string Key { get; set; }
    public Point Destination { get; set; }

    public MazeCommand(string title, Point destination, string key)
    {
        Id = new Guid();
        Title = title;
        Destination = destination;
        Key = key;
    }
}