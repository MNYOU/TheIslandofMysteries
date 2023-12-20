namespace Application.Context;

public interface IViewContext
{
    public string Title { get; }

    public IEnumerable<IViewCommand> Commands { get; }
}