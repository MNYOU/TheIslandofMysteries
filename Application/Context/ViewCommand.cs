namespace Application.Context;

public class ViewCommand : IViewCommand
{
    public char Key { get; }
    public string Title { get; }

    public ViewCommand(char key, string title)
    {
        Key = key;
        Title = title;
    }
}