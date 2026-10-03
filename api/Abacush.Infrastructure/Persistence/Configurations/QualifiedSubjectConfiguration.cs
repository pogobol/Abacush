using Abacush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abacush.Infrastructure.Persistence.Configurations;

internal sealed class QualifiedSubjectConfiguration : IEntityTypeConfiguration<QualifiedSubject>
{
    public void Configure(EntityTypeBuilder<QualifiedSubject> builder)
    {
        builder.ToTable("QualifiedSubjects");
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(entity => entity.Description)
            .HasMaxLength(1000);

        builder.Property(entity => entity.Interface)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(entity => entity.Attributes)
            .HasConversion(JsonValueConverters.DictionaryConverter)
            .Metadata.SetValueComparer(JsonValueConverters.DictionaryComparer);
    }
}
