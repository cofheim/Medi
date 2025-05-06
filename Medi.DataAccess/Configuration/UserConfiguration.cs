using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medi.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(u => u.Role).IsRequired().HasDefaultValue(Roles.Client);
            builder.Property(u => u.Status).IsRequired().HasDefaultValue(UserStatus.Active);
        }
    }
}
