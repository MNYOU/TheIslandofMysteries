namespace Application.Context;

public class ViewContext: IViewContext
{
    public string Title { get; }
    public IEnumerable<IViewCommand> Commands { get; }
    
    public ViewContext(string title, IEnumerable<IViewCommand> commands)
    {
        Title = title;
        Commands = commands;
    }
}