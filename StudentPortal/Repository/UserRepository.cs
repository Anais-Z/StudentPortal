using StudentPortal.Data;
using StudentPortal.Interfaces;
using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        public User GetUser(string firstName, string lastName)
        {
            return _context.Users.Where(x => (x.FirstName == firstName) && (x.LastName == lastName)).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}
