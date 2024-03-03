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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCourse([FromBody] CourseDto courseCreate)
        {
            if (courseCreate == null)
            {
                return BadRequest(ModelState);
            }

            //check if the course name is already registered
            var course = _courseRepository.GetCourses()
                .Where(x => (x.Name.ToLower() == courseCreate.Name.ToLower()))
                .FirstOrDefault();

            //check if the user already exists 
            if (course != null)
            {
                ModelState.AddModelError("", "Course already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if the course object has been created and saved in the database
            if (!_courseRepository.CreateCourse(courseCreate.ToCourseObject()))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");
        }


        [HttpPut("{courseId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCourse(int courseId, [FromBody] CourseDto courseDto)
        {
            //check if courseDto is null
            if (courseDto == null)
            {
                return BadRequest(ModelState);
            }

            //if courseId doesn't exist return
            if (!_courseRepository.CourseExists(courseId))
            {
                return BadRequest(ModelState);
            }

            //if userId doesn't match the id of the user object to be updated
            if (courseId != courseDto.Id)
            {
                return BadRequest(ModelState);
            }

            var course = courseDto.ToCourseObject();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if the user object has been updated
            if (!_courseRepository.UpdateCourse(course))
            {
                ModelState.AddModelError("", "Something went wrong while updating course");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{courseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCourse(int courseId)
        {
            //check if courseId isn't null and it exists
            if (courseId == null)
            {
                return BadRequest(ModelState);
            }

            if (!_courseRepository.CourseExists(courseId))
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = _courseRepository.GetCourseById(courseId);

            //check if course object is removed sucessfully
            if (!_courseRepository.DeleteCourse(course))
            {
                ModelState.AddModelError("", "Something went wrong while deleting course");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted course succesfully");
        }

    }
}
