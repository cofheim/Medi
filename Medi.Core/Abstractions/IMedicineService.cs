using Medi.Core.Models;

namespace Medi.Application.Services
{
    public interface IMedicineService
    {
        Task<Guid> CreateMedicine(Medicine medicine);
        Task<Guid> DeleteMedicine(Guid id);
        Task<List<Medicine>> GetAllMedicines();
        Task<Guid> UpdateMedicine(Guid id, string name, string description, MedicineForm form, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate);
    }
}