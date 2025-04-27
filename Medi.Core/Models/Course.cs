namespace Medi.Core.Models
{
    public enum IntakeFrequency
    {
        Daily,
        Weekly,
        Custom
    }

    public enum Status
    {
        Planned,
        InProgress,
        Taken,
        Skipped,
        Missed
    }
    public class Course
    {
        const int MAX_NAME_LENGTH = 250;
        const int MAX_DESCRIPTION_LENGTH = 250;
        private Course(Guid id, string name, string description, Guid medicineId, int dosage, int amount, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            MedicineId = medicineId;
            Dosage = dosage;
            Amount = amount;
            Frequency = frequency;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public int Dosage { get; } = 0;
        public int Amount { get; } = 0;
        public MedicineForm Form { get; } = MedicineForm.Other;
        public IntakeFrequency Frequency { get; } = IntakeFrequency.Custom;
        public Status Status { get; } = Status.Planned;
        public DateTime StartDate { get; } = DateTime.UtcNow;
        public DateTime EndDate { get; } = DateTime.UtcNow.AddDays(1);

        public static (Course Course, string Error) Create(Guid id, string name, string description, Guid medicineId, int dosage, int amount, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                error = $"Name cannot be empty or longer than {MAX_NAME_LENGTH} symbols";
            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
                error = $"Description cannot be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols";
            if (startDate > endDate || endDate < startDate)
                error = "Start Date cannot be later than End Date or End Date cannot be earlier than Start Date";
            if (dosage < 0)
                error = "Dosage cannot be less than 0";
            if (amount < 0)
                error = "Amount cannot be less than 0";
            var course = new Course(id, name, description, medicineId, dosage, amount, frequency, status, startDate, endDate);

            return (course, error);

        }

        // связи
        public Medicine Medicine { get; }
        public Guid MedicineId { get; }

    }
}
