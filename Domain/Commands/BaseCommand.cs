namespace Domain.Commands;

public abstract class BaseCommand: ICommand
{
    public char Key { get;}
    public string Title { get; }

    protected BaseCommand(char key, string title)
    {
        if (!char.IsLetterOrDigit(key))
            throw new ArgumentException();
        Key = key;
        Title = title;
    }

    public abstract void Execute();
}