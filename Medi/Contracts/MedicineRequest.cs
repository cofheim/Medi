using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record MedicineRequest (string name, string description, MedicineForm form, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate);
}
