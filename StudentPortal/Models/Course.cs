using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseDescription { get; set; }

        public List<int> StudentIds { get; set; }

        public User Professor { get; set; }
    }
}
