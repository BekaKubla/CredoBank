using KredoBank.Domain.Repositories;
using KredoBank.Domain.SeedWork;
using KredoBank.Infrastructure.Persistence.Context;
using System.Threading.Tasks;

namespace KredoBank.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KredoBankDbContext _context;
        public UnitOfWork(
            KredoBankDbContext context,
            IStatementRepository statementRepository,
            IUserRepository userRepository
            )
        {
            _context = context;
            StatementRepository = statementRepository;
            UserRepository = userRepository;
        }
        public IStatementRepository StatementRepository { get; }

        public IUserRepository UserRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
