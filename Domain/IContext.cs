namespace Domain;

public interface IContext
{
    public string Title { get; }

    // public string ProgressTitle { get; set; }
    
    public IEnumerable<ICommand> GetAvailableActions();

    // public void Execute(IReadOnlyCommand command);
}