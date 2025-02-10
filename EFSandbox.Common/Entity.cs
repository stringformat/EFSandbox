namespace EFSandbox.Common;

public abstract class Entity
{
    public int Id { get; }

    protected Entity()
    {
        Id = 0;
    }
}