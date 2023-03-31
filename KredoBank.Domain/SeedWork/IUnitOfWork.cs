using KredoBank.Domain.Repositories;
using System.Threading.Tasks;

namespace KredoBank.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        IStatementRepository StatementRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
