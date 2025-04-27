using Microsoft.EntityFrameworkCore;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medi.DataAccess.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(k => k.Name).IsRequired().HasMaxLength(250);
            builder.Property(k => k.Description).IsRequired().HasMaxLength(250);
            builder.Property(k => k.MedicineId).IsRequired();
            builder.Property(k => k.Dosage).IsRequired();
            builder.Property(k => k.Amount).IsRequired();
            builder.Property(k => k.StartDate).IsRequired();
            builder.Property(k => k.EndDate).IsRequired();
            builder.Property(k => k.Frequency).IsRequired().HasConversion<string>();
            builder.Property(k => k.Status).IsRequired().HasConversion<string>();
        }
    }
}
