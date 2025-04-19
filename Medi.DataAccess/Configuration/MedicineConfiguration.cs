using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medi.DataAccess.Config
{
    public class MedicineConfiguration : IEntityTypeConfiguration<MedicineEntity>
    {
        public void Configure(EntityTypeBuilder<MedicineEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(250);
            builder.Property(m => m.StartDate).IsRequired();
            builder.Property(m => m.EndDate).IsRequired();
        }
    }
}
