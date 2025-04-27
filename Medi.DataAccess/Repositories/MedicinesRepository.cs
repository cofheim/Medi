using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Medi.DataAccess.Repositories
{
    public class MedicinesRepository : IMedicinesRepository
    {
        private readonly MediDbContext _context;
        public MedicinesRepository(MediDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> Get()
        {
            var medicineEntities = await _context.Medicines.AsNoTracking().ToListAsync();
            var medicines = medicineEntities.Select(m => Medicine.Create(m.Id, m.Name, m.Description, m.Form).Medicine).ToList();

            return medicines;
        }

        public async Task<Guid> Create(Medicine medicine)
        {
            var medicineEntity = new MedicineEntity
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Description = medicine.Description,
                Form = medicine.Form
            };

            await _context.Medicines.AddAsync(medicineEntity);
            await _context.SaveChangesAsync();

            return medicineEntity.Id;

        }

        public async Task<Guid> Update(Guid id, string name, string description, MedicineForm form)
        {
            await _context.Medicines
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(s => s
            .SetProperty(m => m.Name, m => name)
            .SetProperty(m => m.Description, m => description)
            .SetProperty(m => m.Form, m => form));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Medicines.Where(m => m.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
