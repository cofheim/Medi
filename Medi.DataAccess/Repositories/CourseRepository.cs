using System.Xml.Linq;
using Medi.Core.Models;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medi.DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MediDbContext _context;

        public CourseRepository(MediDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Course course)
        {
            var courseEntity = new CourseEntity()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                MedicineId = course.MedicineId,
                Dosage = course.Dosage,
                Amount = course.Amount,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Frequency = course.Frequency,
                Status = course.Status
            };

            await _context.Courses.AddAsync(courseEntity);
            await _context.SaveChangesAsync();

            return courseEntity.Id;

        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Courses.Where(m => m.Id == id).ExecuteDeleteAsync();

            return id;
        }

        public async Task<List<Course>> Get()
        {
            var courseEntities = await _context.Courses.AsNoTracking().ToListAsync();
            var courses = courseEntities.Select(m => Course.Create(m.Id, m.Name, m.Description, m.MedicineId, m.Dosage, m.Amount, m.Frequency, m.Status, m.StartDate, m.EndDate).Course).ToList();

            return courses;
        }

        public async Task<Guid> Update(Guid id,
            string name,
            string description,
            Guid medicineId,
            int dosage, 
            int amount,
            IntakeFrequency frequency,
            Status status,
            DateTime startDate,
            DateTime endDate)
        {
            await _context.Courses
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(s => s
            .SetProperty(m => m.Name, m => name)
            .SetProperty(m => m.Description, m => description)
            .SetProperty(m => m.MedicineId, m => medicineId)
            .SetProperty(m => m.Dosage, m => dosage)
            .SetProperty(m => m.Frequency, m => frequency)
            .SetProperty(m => m.Status, m => status)
            .SetProperty (m => m.StartDate, startDate)
            .SetProperty (m => m.EndDate, endDate)
            );

            return id;
        }

    }
}
