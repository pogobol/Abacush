using Abacush.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abacush.Infrastructure.Persistence;

public sealed class AbacushDbContext : DbContext
{
    public DbSet<QualifiedType> QualifiedTypes => Set<QualifiedType>();
    public DbSet<QualifiedSubject> QualifiedSubjects => Set<QualifiedSubject>();
    public DbSet<QualifiedObject> QualifiedObjects => Set<QualifiedObject>();
    public DbSet<Permission> Permissions => Set<Permission>();

    public AbacushDbContext(DbContextOptions<AbacushDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbacushDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
