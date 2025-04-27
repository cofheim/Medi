using Medi.Core.Models;

namespace Medi.DataAccess.Repositories
{
    public interface ICourseRepository
    {
        Task<Guid> Create(Course course);
        Task<Guid> Delete(Guid id);
        Task<List<Course>> Get();
        Task<Guid> Update(Guid id, 
            string name, 
            string description, 
            Guid medicine, 
            int dosage, int amount, 
            IntakeFrequency frequency, 
            Status status, 
            DateTime startDate, 
            DateTime endDate);
    }
}