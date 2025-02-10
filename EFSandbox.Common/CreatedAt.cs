namespace EFSandbox.Common;

public record CreatedAt
{
    public const int MAX_YEAR = 2030;
        
    public DateTimeOffset Value { get; }

    private CreatedAt(DateTimeOffset value)
    {
        Value = value;
    }

    public static CreatedAt Create(DateTimeOffset value)
    {
        if (value.Year > MAX_YEAR)
            return null;
            
        return new(value);
    }
}