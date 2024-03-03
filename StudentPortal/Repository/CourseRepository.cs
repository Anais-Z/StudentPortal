using StudentPortal.Data;
using StudentPortal.Interfaces;
using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Course> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.Id).ToList();
        }
    }
}
