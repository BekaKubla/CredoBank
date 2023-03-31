using KredoBank.Domain.Entity.User;
using KredoBank.Domain.Repositories;
using KredoBank.Infrastructure.Persistence.Context;
using KredoBank.Infrastructure.SeedWork;

namespace KredoBank.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users, KredoBankDbContext>, IUserRepository
    {
        public UserRepository(KredoBankDbContext context) : base(context)
        {

        }
    }
}
