using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.UserId).IsRequired();
        builder.Property(s => s.ExternalId).IsRequired().HasMaxLength(50);
        builder.Property(u => u.CreatedAt).HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnType("timestamp with time zone");
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}