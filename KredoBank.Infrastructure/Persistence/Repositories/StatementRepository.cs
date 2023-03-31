using KredoBank.Domain.Entity.Statement;
using KredoBank.Domain.Repositories;
using KredoBank.Infrastructure.Persistence.Context;
using KredoBank.Infrastructure.SeedWork;

namespace KredoBank.Infrastructure.Persistence.Repositories
{
    public class StatementRepository : GenericRepository<Statements, KredoBankDbContext>, IStatementRepository
    {
        public StatementRepository(KredoBankDbContext context) : base(context)
        {

        }
    }
}
