namespace Domain;

public interface IReadOnlyCommand
{
    // public Guid Id { get; set; }

    public string Title { get; }

    public string Key { get; set; }
    // string key
}