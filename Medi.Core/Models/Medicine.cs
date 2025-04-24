namespace Medi.Core.Models
{
    public enum MedicineForm 
    { 
        Capsule,
        Tablet,
        Liquid,
        Injection,
        Other
    }
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

    public class Medicine
    {
        const int MAX_NAME_LENGTH = 50;
        const int MAX_DESCRIPTION_LENGTH = 250;
        private Medicine(Guid id, string name, string description, MedicineForm form, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Form = form;
            Frequency = frequency;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public MedicineForm Form { get;} = MedicineForm.Other;
        public IntakeFrequency Frequency { get; } = IntakeFrequency.Custom;
        public Status Status { get; } = Status.Planned;
        public DateTime StartDate { get; } = DateTime.UtcNow;
        public DateTime EndDate { get; }

        public static (Medicine Medicine, string Error) Create(Guid id, string name, string description, MedicineForm form, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                error = $"Name cannot be empty or longer than {MAX_NAME_LENGTH} symbols";            
            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
                error = $"Description cannot be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols";
            if (startDate > endDate || endDate < startDate)
                error = "Start Date cannot be later than End Date or End Date cannot be earlier than Start Date";

            var medicine = new Medicine(id, name, description, form, frequency, status, startDate, endDate);

            return (medicine, error);

        }
    }
}
