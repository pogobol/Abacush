using Abacush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abacush.Infrastructure.Persistence.Configurations;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");
        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Object)
            .WithMany()
            .HasForeignKey(entity => entity.ObjectId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(entity => entity.Subjects)
            .WithMany()
            .UsingEntity(join => join.ToTable("PermissionSubjects"));

        builder.Property(entity => entity.Actions)
            .HasConversion(JsonValueConverters.StringListConverter)
            .Metadata.SetValueComparer(JsonValueConverters.StringListComparer);
    }
}
