using Medi.API.Contracts;
using Medi.Application.Services;
using Medi.Core.Models;
using Medi.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService coursesService)
        {
            _courseService = coursesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();

            var response = courses.Select(m => new CourseResponse(
                m.Id, 
                m.Name, 
                m.Description, 
                m.MedicineId, 
                m.Dosage, 
                m.Amount, 
                m.Frequency, 
                m.Status, 
                m.StartDate, 
                m.EndDate));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourse([FromBody] CourseRequest request)
        {
            try
            {
                var (course, error) = Course.Create(Guid.NewGuid(),
                    request.name,
                    request.description,
                    request.medicineId,
                    request.dosage,
                    request.amount,
                    request.frequency,
                    request.status,
                    request.startDate,
                    request.endDate);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var courseId = await _courseService.CreateCourse(course);
                return Ok(courseId);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCourse(Guid id, [FromBody] CourseRequest request)
        {
            var courseId = await _courseService.UpdateCourse(id, 
                request.name,
                request.description,
                request.medicineId,
                request.dosage,
                request.amount,
                request.frequency,
                request.status,
                request.startDate,
                request.endDate);

            return Ok(courseId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCourse(Guid id)
        {
            return Ok(await _courseService.DeleteCourse(id));
        }
    }
}
