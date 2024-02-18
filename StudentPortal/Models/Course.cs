namespace StudentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseId { get; set; }

        public string CourseDescription { get; set; }

        public List<User> Students { get; set; }

        public User Proffesor { get; set; }
    }
}
