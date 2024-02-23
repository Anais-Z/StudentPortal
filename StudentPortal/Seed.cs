using StudentPortal.Data;
using StudentPortal.Models;
using System.Diagnostics.Metrics;

namespace StudentPortal
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.UserCourses.Any())
            {
                var userCourses = new List<UserCourse>()
                {
                    new UserCourse()
                    {
                        User = new User()
                        {
                            FirstName = "Peter",
                            LastName = "Parker",
                            Email = "peterparker@gmail.com",
                            Password= "password",
                            Addresses = new List<Address>()
                            {
                               new Address { City = "New York City", Province = "New York", Street = "Queens", PostalCode = "IIII"},
                               new Address { City = "New York City", Province = "New York", Street = "Manhatten", PostalCode = "IIII"},
                               new Address { City = "New York City", Province = "New York", Street = "Hell's Kitchen", PostalCode = "IIII"},
                            }
                        },
                        Course= new Course() 
                        {
                            Name = "Intro to Biology",
                            CourseDescription = "Introduction to Biology",
                            UserCount = 30
                        },

                        Grade = 90
                        
                    },
                    new UserCourse()
                    {
                        User = new User()
                        {
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            Email = "wayne@gmail.com",
                            Password= "password",
                            Addresses = new List<Address>()
                            {
                               new Address { City = "Gotham City", Province = "New Jesery", Street = "Crime Alley", PostalCode = "IIII"},
                               new Address { City = "Gotham City", Province = "New Jesery", Street = "Arkham Asylum", PostalCode = "IIII"},
                               new Address { City = "Gotham City", Province = "New Jesery", Street = "Wayne Manor", PostalCode = "IIII"},
                            }
                        },
                        Course= new Course()
                        {
                            Name = "Intro to Technology",
                            CourseDescription = "Some tech course",
                            UserCount = 45
                        },
                        
                        Grade = 95

                    },
                    new UserCourse()
                    {
                        User = new User()
                        {
                            FirstName = "Clark",
                            LastName = "Kent",
                            Email = "kent@gmail.com",
                            Password= "password",
                            Addresses = new List<Address>()
                            {
                               new Address { City = "Metropolis", Province = "California", Street = "Random Street", PostalCode = "IIII"},
                               new Address { City = "Smallville", Province = "California", Street = "Kent Farm", PostalCode = "IIII"},
                            }
                        },
                        Course= new Course()
                        {
                            Name = "Intro to Photography",
                            CourseDescription = "Learn how to take pictures and write papers.",
                            UserCount = 22
                        },

                        Grade = 83

                    },

                };
                dataContext.UserCourses.AddRange(userCourses);
                dataContext.SaveChanges();
            }
        }
    }
}
