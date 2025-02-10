using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFSandbox.Infrastructure.Common;

public class ReadContext(DbContextOptions<Context> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

public class ReadContextFactory : IDesignTimeDbContextFactory<ReadContext>
{
    public ReadContext CreateDbContext(string[] args)
    {
        throw new InvalidOperationException("Design-time context creation is not supported for read context.");
    }
}