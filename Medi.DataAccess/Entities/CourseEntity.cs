using Medi.Core.Models;

namespace Medi.DataAccess.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Dosage { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public MedicineForm Form { get; set; } = MedicineForm.Other;
        public IntakeFrequency Frequency { get; set; } = IntakeFrequency.Custom;
        public Status Status { get; set; } = Status.Planned;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(1);
        public MedicineEntity Medicine { get; set; }
        public Guid MedicineId { get; set; }
    }
}
