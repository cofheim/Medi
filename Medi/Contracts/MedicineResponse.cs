
using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record MedicineResponse(Guid id, string name, string description, MedicineForm form, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate);
}
