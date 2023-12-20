namespace Domain.Commands;

public class ExitCommand: IReadOnlyCommand
{
    public Guid Id { get; set; }
    public string Title { get; }
    public string Key { get; set; }
}