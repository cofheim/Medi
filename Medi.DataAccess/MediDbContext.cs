using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medi.DataAccess
{
    public class MediDbContext : DbContext
    {
        public MediDbContext(DbContextOptions<MediDbContext> options) : base(options)
        {

        }
        public DbSet<MedicineEntity> Medicines { get; set; }

    }
}
