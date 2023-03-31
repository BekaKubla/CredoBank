using KredoBank.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KredoBank.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        }
    }
}
