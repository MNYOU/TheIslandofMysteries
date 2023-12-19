using ConsoleApp.CommandsExecutor;
using ConsoleApp.UserInterfaces;

internal class Program
{
    public static void Main(string[] args)
    {
        var consoleExecutorFactory = new ConsoleExecutorFactory();
        var executor = consoleExecutorFactory.CreateExecutor();
        if (args.Length > 0)
            executor.Execute(args);
        else
            RunInteractiveMode(executor);
    }

    static void RunInteractiveMode(ICommandsExecutor executor)
    {
        var userInterface = new ConsoleUserInterface(Console.In, Console.Out, executor);
        while (true)
        {
            var line = userInterface.GetCommandName();
            userInterface.HandleUserInput(line);
        }
    }
}