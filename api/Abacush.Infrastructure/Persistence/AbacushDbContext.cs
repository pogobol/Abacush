using Microsoft.EntityFrameworkCore;

namespace Abacush.Infrastructure.Persistence;

public sealed class AbacushDbContext : DbContext
{
    public AbacushDbContext(DbContextOptions<AbacushDbContext> options)
        : base(options)
    {
    }
}
