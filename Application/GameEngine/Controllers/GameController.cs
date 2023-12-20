using Application.Context;
using Domain;

namespace Application;

public class GameController
{
    private IContext _context;
    private readonly IContextProvider _contextProvider;


    public GameController(IContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
        _context = _contextProvider.GetContext();
    }

    public IViewContext GetCurrentContext()
    {
        UpdateContext();
        var commands = _context
            .GetAvailableActions()
            .Select(c => new ViewCommand(c.Key, c.Title));
        return new ViewContext(_context.Title, commands);
    }

    public void ExecuteCommand(char key)
    {
        UpdateContext();
        var command = _context.GetAvailableActions().FirstOrDefault(c => c.Key == key);
        if (command == null)
            throw new ArgumentException();
        command.Execute();
    }

    private void UpdateContext()
    {
        _context = _contextProvider.GetContext();
    }
}