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

        public bool CourseExists(int id)
        {
            _context.Courses.Where(c => c.Id == id).FirstOrDefault();
            return true;
        }

        public bool CreateCourse(Course course)
        {
            _context.Add(course);
            return Save();
        }

        public bool DeleteCourse(Course course)
        {
            _context.Remove(course);
            return Save();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Course> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.Id).ToList();
        }

        public bool UpdateCourse(Course course)
        {
            _context.ChangeTracker.Clear();
            _context.Update(course);
            return Save();
        }

        public bool Save()
        {
            
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
