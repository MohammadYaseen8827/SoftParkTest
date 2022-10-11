using Platform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(200)
            .IsRequired();
        builder
            .OwnsOne(b => b.Address);
    }
}
