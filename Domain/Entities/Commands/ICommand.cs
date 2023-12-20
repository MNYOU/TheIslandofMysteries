namespace Domain;

public interface ICommand: IReadOnlyCommand
{
    public string Title { get; }

    public string Type { get; set; }
}