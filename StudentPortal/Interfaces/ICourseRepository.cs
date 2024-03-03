using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCourses();
    }
}
