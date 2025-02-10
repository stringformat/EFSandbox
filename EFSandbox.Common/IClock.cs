namespace EFSandbox.Common;

public interface IClock
{
    public DateTimeOffset Now { get; }
}