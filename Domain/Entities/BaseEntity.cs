namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != GetType())
            return false;
        return Id == ((BaseEntity)obj).Id;
    }
}