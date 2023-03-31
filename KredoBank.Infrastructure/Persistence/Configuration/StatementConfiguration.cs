using KredoBank.Domain.Entity.Statement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KredoBank.Infrastructure.Persistence.Configuration
{
    public class StatementConfiguration : IEntityTypeConfiguration<Statements>
    {
        public void Configure(EntityTypeBuilder<Statements> builder)
        {
            builder.ToTable("Statements");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreateStatementDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(d => d.User)
                   .WithMany(e => e.Statements)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
