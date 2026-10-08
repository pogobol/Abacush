using Abacush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abacush.Infrastructure.Persistence.Configurations;

internal sealed class QualifiedTypeConfiguration : IEntityTypeConfiguration<QualifiedType>
{
    public void Configure(EntityTypeBuilder<QualifiedType> builder)
    {
        builder.ToTable("QualifiedTypes");
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(entity => entity.Description)
            .HasMaxLength(1000);

        builder.Property(entity => entity.Interface)
            .IsRequired()
            .HasColumnType("nvarchar(max)");
    }
}
