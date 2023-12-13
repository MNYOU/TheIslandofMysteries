using ConsoleApp.Commands;
using ConsoleApp.CommandsExecutor;

internal class Program
{
    public static void Main(string[] args)
    {
        ICommandsExecutor executor = CreateExecutor();
        if (args.Length > 0)
            executor.Execute(args);
        else
            RunInteractiveMode(executor);
    }

    static void RunInteractiveMode(ICommandsExecutor executor)
    {
        while (true)
        {
            var line = Console.ReadLine(); ///TODO: здесь нужно подумать о получении сообщения от пользователя
            if (line == null || line == "exit")
                return;
            executor.Execute(line.Split(' '));
        }
    }

    static ICommandsExecutor CreateExecutor()
    {
        var executor = new CommandsExecutor(Console.Out, Console.In);
        executor.Register(new StartGameCommand("start"));
        //executor.Register(new LoadCommand("loads"));
        return executor;
    }
}