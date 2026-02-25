using Demo.Domain.Abstractions;

namespace Demo.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.BeginTransactionAsync();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
