using Application.GameEngine;
using Application.GameEngine.Controllers;
using Domain;

internal class Program
{
    public static void Main(string[] args)
    {
        var launcher = new GameLauncher();

        var controller = new GameController();
        Console.WriteLine("Вы начинаете игру \"Остров загадок\"!\nБудет весело, до жути!");

        var game = launcher.Start();
        while (true)
        {
            var context = game.GetContext();
            Console.WriteLine(context.Title);
            var commands = context.GetAvailableActions();
            Write(commands);
            var userInput = Console.ReadKey();
            var selected = commands.FirstOrDefault(c => c.Key == userInput.KeyChar);
            if (selected == null)
            {
                Console.WriteLine("Ошибка. Неверный ввод!");
                continue;
            }

            game.Execute(selected);
        }
    }

    private static void Write(IEnumerable<ICommand> commands)
    {
        Console.WriteLine("Выберите действия: ");
        foreach (var command in commands)
        {
            Console.WriteLine($"{command.Key} {command.Title}");
        }
    }
}