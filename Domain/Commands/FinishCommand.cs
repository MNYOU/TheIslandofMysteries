namespace Domain.Commands;

public class FinishCommand: ICommand
{
    public char Key => 'e';
    public string Title => "Закончить игру";
    public void Execute()
    {
        
        Environment.Exit(1);
    }
}