namespace Domain;

public interface IContext
{
    public string Title { get; }

    // public string ProgressTitle { get; set; }
    
    public IEnumerable<IReadOnlyCommand> GetAvailableActions();

    public void Execute(IReadOnlyCommand command);
}