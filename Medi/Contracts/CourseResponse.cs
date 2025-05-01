using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record CourseResponse(Guid id, 
        string name, 
        string description, 
        Guid medicineId,
        string medicineName,
        int dosage, 
        int amount, 
        IntakeFrequency frequency, 
        Status status, 
        DateTime startDate, 
        DateTime endDate);
}
