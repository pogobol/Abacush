using Abacush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abacush.Infrastructure.Persistence.Configurations;

internal sealed class QualifiedObjectConfiguration : IEntityTypeConfiguration<QualifiedObject>
{
    public void Configure(EntityTypeBuilder<QualifiedObject> builder)
    {
        builder.ToTable("QualifiedObjects");
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(entity => entity.Description)
            .HasMaxLength(1000);

        builder.Property(entity => entity.Attributes)
            .HasConversion(JsonValueConverters.DictionaryConverter)
            .Metadata.SetValueComparer(JsonValueConverters.DictionaryComparer);

        builder.Property(entity => entity.TypeId)
            .IsRequired();

        builder.HasOne(entity => entity.Type)
            .WithMany()
            .HasForeignKey(entity => entity.TypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
