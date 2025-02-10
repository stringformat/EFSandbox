using EFSandbox.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSandbox.Infrastructure.Tasks;

public class ScheduleTask(string name) : Entity, IAggregateRoot
{
    public string Name { get; } = name;
}

public class EntityConfiguration : IEntityTypeConfiguration<ScheduleTask>
{
    public void Configure(EntityTypeBuilder<ScheduleTask> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name);
    }
}