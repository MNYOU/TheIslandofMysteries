namespace Application.Context;

public interface IViewCommand
{
    public char Key { get; }

    public string Title { get; }
}