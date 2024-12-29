using TechnicalAPI.Connection;
using TechnicalAPI.Repo.Movs;

namespace TechnicalAPI.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        ConnectionDB Connection { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConnectionDB _connection;

        public UnitOfWork(ConnectionDB connection)
        {
            _connection = connection;
        }

        public ConnectionDB Connection => _connection;

        public async Task CommitAsync()
        {
            await Task.Run(() => _connection.transaction.Commit());
        }

        public async Task RollbackAsync()
        {
            await Task.Run(() => _connection.transaction.Rollback());
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }


}
