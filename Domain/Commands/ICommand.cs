namespace Domain;

public interface ICommand
{
    public char Key { get;}

    public string Title { get; }

    public void Execute();
}