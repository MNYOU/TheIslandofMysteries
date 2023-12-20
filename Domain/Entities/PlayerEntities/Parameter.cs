namespace Domain.Entities.PlayerEntities;

public class Parameter
{
    public ParameterType Type { get; set; }

    public int Value { get; set; }
    public int MaxValue { get; }

    public Parameter(ParameterType type, int value, int maxValue)
    {
        if (value  < 0 || value > maxValue)
            throw new ArgumentException();
        if (maxValue < 0 || value > maxValue)
            throw new ArgumentException();
        Type = type;
        Value = value;
        MaxValue = maxValue;
    }
}