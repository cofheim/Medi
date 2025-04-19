namespace Medi.Core.Models
{
    public enum MedicineForm 
    { 
        Taken,
        Missed,
        Skipped
    }

    public class Medicine
    {
        const int MAX_NAME_LENGTH = 50;
        const int MAX_DESCRIPTION_LENGTH = 250;
        private Medicine(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public MedicineForm Form { get;}
        public DateTime StartDate { get; } = DateTime.UtcNow;
        public DateTime EndDate { get; }

        public static (Medicine Medicine, string Error) Create(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                error = $"Name cannot be empty or longer than {MAX_NAME_LENGTH} symbols";            
            if (string.IsNullOrEmpty(description) || name.Length > MAX_DESCRIPTION_LENGTH)
                error = $"Description cannot be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols";

            var medicine = new Medicine(id, name, description, startDate, endDate);

            return (medicine, error);

        }
    }
}
