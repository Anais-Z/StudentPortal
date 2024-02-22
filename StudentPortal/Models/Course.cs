using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserCount { get; set; }
        public string CourseDescription { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }

    }
}
