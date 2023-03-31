using KredoBank.Domain.Entity.Statement;
using KredoBank.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace KredoBank.Infrastructure.Persistence.Context
{
    public class KredoBankDbContext : DbContext
    {
        public KredoBankDbContext(DbContextOptions<KredoBankDbContext> options) : base(options)
        {

        }

        public DbSet<Statements> Statements { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KredoBankDbContext).Assembly);
        }
    }
}
