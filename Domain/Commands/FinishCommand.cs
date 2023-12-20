namespace Domain.Commands;

public class FinishCommand: IReadOnlyCommand
{
    public Guid Id { get; set; }
    public string Title => "Закончить игру";
    public string Key { get; set; }

    public FinishCommand()
    {
        Key = "e";
        // Title = "Что... ж. В этот раз вам повезло. Удачи, ведь скоро вы снова вернетесь на остров";
        
    }
}