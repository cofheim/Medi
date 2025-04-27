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

    public class Medicine
    {
        const int MAX_NAME_LENGTH = 50;
        const int MAX_DESCRIPTION_LENGTH = 250;
        private Medicine(Guid id, string name, string description, MedicineForm form)
        {
            Id = id;
            Name = name;
            Description = description;
            Form = form;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public MedicineForm Form { get;} = MedicineForm.Other;

        public static (Medicine Medicine, string Error) Create(Guid id, string name, string description, MedicineForm form)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                error = $"Name cannot be empty or longer than {MAX_NAME_LENGTH} symbols";            
            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
                error = $"Description cannot be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols";

            var medicine = new Medicine(id, name, description, form);

            return (medicine, error);

        }

        // связи
        public List<Course> Courses { get; } = new List<Course>();
    }
}
