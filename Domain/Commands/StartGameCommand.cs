using Domain.Entities;

namespace Domain.Commands;

public class StartGameCommand: ICommand
{
    private readonly Game _game;

    public StartGameCommand(Game game)
    {
        _game = game;
    }
    
    public char Key => 's';

    public string Title => "Начать игру";
    
    public void Execute()
    {
        // TODO
    }
}