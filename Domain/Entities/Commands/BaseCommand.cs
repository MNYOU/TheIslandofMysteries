namespace Domain.Entities.Commands;

public class BaseCommand: IReadOnlyCommand
{
    public Guid Id { get; set; }
    public string Title { get; }
    public string Key { get; set; }

    public BaseCommand(string key, string title)
    {
        Key = key;
        Title = title;
    }
}