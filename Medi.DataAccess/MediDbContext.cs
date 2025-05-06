using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Medi.Core.Models;

namespace Medi.DataAccess
{
    public class MediDbContext : DbContext
    {
        public MediDbContext(DbContextOptions<MediDbContext> options) : base(options)
        {

        }
        public DbSet<MedicineEntity> Medicines { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineEntity>()
                .HasMany(m => m.Courses)
                .WithOne(m => m.Medicine)
                .HasForeignKey(c => c.MedicineId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Courses); 
            
            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Medicines);


        }

    }
}
