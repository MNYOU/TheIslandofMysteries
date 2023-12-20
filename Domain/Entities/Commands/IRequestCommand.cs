namespace Domain.Entities.Commands;

public interface IRequestCommand
{
    public Guid Id { get; set; }

    public string Title { get; }
}