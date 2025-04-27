using Medi.Core.Models;
using Medi.DataAccess.Repositories;

namespace Medi.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicinesRepository _medicinesRepository;
        public MedicineService(IMedicinesRepository medicinesRepository)
        {
            _medicinesRepository = medicinesRepository;
        }
         
        public async Task<List<Medicine>> GetAllMedicines()
        {
            return await _medicinesRepository.Get();
        }

        public async Task<Guid> CreateMedicine(Medicine medicine)
        {
            return await _medicinesRepository.Create(medicine);
        }

        public async Task<Guid> UpdateMedicine(Guid id, string name, string description, MedicineForm form)
        {
            return await _medicinesRepository.Update(id, name, description, form);
        }

        public async Task<Guid> DeleteMedicine(Guid id)
        {
            return await _medicinesRepository.Delete(id);
        }

    }
}
