namespace Domain.Commands;

public class ExitCommand: ICommand
{
    public char Key => 'e';
    public string Title => "Выйти из игры";
    public void Execute()
    {
        Environment.Exit(1);
    }
}