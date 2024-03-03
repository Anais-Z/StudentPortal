using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCourses();

        Course GetCourseById(int id);

        bool CreateCourse(Course course);

        bool CourseExists(int id);

        bool UpdateCourse(Course course);

        bool DeleteCourse(Course course);

    }
}
