using EFSandbox.Domain.UsersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSandbox.Infrastructure.Users;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(q => q.Id);
        
        builder.ComplexProperty(s => s.Name, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(User.Name));
        });
    }
}