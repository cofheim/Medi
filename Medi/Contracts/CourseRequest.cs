using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record CourseRequest (Guid id,
        string name,
        string description,
        Guid medicineId,
        int dosage,
        int amount,
        IntakeFrequency frequency,
        Status status,
        DateTime startDate,
        DateTime endDate);
}
