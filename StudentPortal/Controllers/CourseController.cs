using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Interfaces;
using StudentPortal.Mappers;
using StudentPortal.Models;
using StudentPortal.Repository;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController: Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var courses = _courseRepository.GetCourses();

            var coursesDto = courses.Select(x => x.ToCourseDto());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetCourse(int id)
        {
            var course = _courseRepository.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDto = course.ToCourseDto();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(courseDto);
        }

    }
}
