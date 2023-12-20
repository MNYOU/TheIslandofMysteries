namespace Domain.Entities.PlayerEntities;

public class Parameter
{
    public ParameterType Type { get; set; }

    public int Value { get; set; }

    public Parameter(ParameterType type, int value)
    {
        if (value is < 0 or > 100)
            throw new ArgumentException();
        Type = type;
        Value = value;
    }
}