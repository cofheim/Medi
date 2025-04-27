using Medi.Core.Models;

namespace Medi.Application.Services
{
    public interface ICourseService
    {
        Task<Guid> CreateCourse(Course course);
        Task<Guid> DeleteCourse(Guid id);
        Task<List<Course>> GetAllCourses();
        Task<Guid> UpdateCourse(Guid id, string name, string description, Guid medicineId, int dosage, int amount, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate);
    }
}