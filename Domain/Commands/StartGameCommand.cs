namespace Domain.Commands;

public class StartGameCommand: IReadOnlyCommand
{
    public Guid Id { get; set; }
    public string Title { get; }
    public string Key { get; set; }

    public StartGameCommand()
    {
        Title = "Начать игру";
        Key = "n";
    }
}