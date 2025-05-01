using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;
using Medi.DataAccess.Repositories;

namespace Medi.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMedicinesRepository _medicinesRepository;
        public CourseService(ICourseRepository coursesRepository, IMedicinesRepository medicinesRepository) 
        {
            _courseRepository = coursesRepository;
            _medicinesRepository = medicinesRepository;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.Get();
        }

        public async Task<Guid> CreateCourse(Course course)
        {
            var medicines = await _medicinesRepository.Get();
            if (!medicines.Any(m => m.Id == course.MedicineId))
            {
                throw new InvalidOperationException($"Medicine with ID {course.MedicineId} does not exist");
            }

            return await _courseRepository.Create(course);
        }

        public async Task<Guid> UpdateCourse(Guid id, string name, string description, Guid medicineId, int dosage, int amount, IntakeFrequency frequency, Status status, DateTime startDate, DateTime endDate)
        {
            return await _courseRepository.Update(id, name, description, medicineId, dosage, amount, frequency, status, startDate, endDate);
        }

        public async Task<Guid> DeleteCourse(Guid id)
        {
            return await _courseRepository.Delete(id);
        }
    }
}
