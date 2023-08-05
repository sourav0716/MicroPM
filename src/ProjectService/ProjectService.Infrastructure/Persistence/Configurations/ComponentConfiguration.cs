using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectService.Domain.Entity;

namespace ProjectService.Infrastructure.Persistence.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("components");
        builder.HasKey(c => new { c.Id, c.ProjectId });
        builder.Property(c => c.Id)
            .HasColumnName("componentid")
            .ValueGeneratedNever();
        builder.Property(c => c.ProjectId)
            .HasColumnName("projectid");
        builder.OwnsOne(c => c.Details)
            .Property(d => d.Name)
            .HasColumnName("componentname")
            .IsRequired()
            .HasMaxLength(50);
        builder.OwnsOne(c => c.Details)
            .Property(d => d.Description)
            .HasColumnName("componentdescription")
            .HasMaxLength(100);
        builder.HasOne(c => c.Project)
            .WithMany(p => p.Components)
            .HasForeignKey(c => c.ProjectId);

        builder.HasIndex(c => c.ProjectId).HasDatabaseName("idx_components_projectid");
        builder.HasIndex(c => c.Details.Name).HasDatabaseName("idx_components_componentname");
    }
}