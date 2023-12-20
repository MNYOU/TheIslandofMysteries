using Application;
using Application.Context;
using Application.GameEngine;
using static System.Console;

internal class Program
{
    private static GameController _controller;
    
    public static void Main(string[] args)
    {
        Initialize();
        WriteLine("Вы начинаете игру \"Остров загадок\"!\nБудет весело, до жути!");
        
        while (true)
        {
            var context = _controller.GetCurrentContext();
            WriteLine(context.Title);
            // var commands = context.GetAvailableActions();
            Write(context.Commands);
            var userInput = ReadLine();

            try
            {
                _controller.ExecuteCommand(userInput[0]);
            }
            catch (Exception e)
            {
                WriteLine("Ошибка при выполнении команды! ", e);
                throw;
            }
        }
    }

    public static void Initialize()
    {
        var launcher = new GameLauncher();
        var game = launcher.Start();
        var context = new ContextProvider(game);
        _controller = new GameController(context);
    }

    private static void Write(IEnumerable<IViewCommand> commands)
    {
        WriteLine("Выберите действия: ");
        foreach (var command in commands)
        {
            WriteLine($"{command.Key} {command.Title}");
        }
    }
}