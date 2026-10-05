namespace Abacush.Domain.Interfaces;

public interface IUnitOfWork
{
    IObjectTypeRepository ObjectTypes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
