using Domain.Entities.Locations;

namespace Domain.Commands.Locations;

public class GoToNextCommand: BaseCommand, ICommand
{
    private readonly Location _location;
    
    public GoToNextCommand(Location location) : base('n', "Перейти к следующему испытанию.")
    {
        _location = location;
    }

    public override void Execute()
    {
        _location.GoToNextChallenge();
    }
}