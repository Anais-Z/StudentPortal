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

        public bool CreateUser(User user)
        {
             _context.Add(user);
            return Save();
        }

        public User GetUser(string firstName, string lastName)
        {
            return _context.Users.Where(x => (x.FirstName == firstName) && (x.LastName == lastName)).FirstOrDefault();
        }

        public User GetUserById(int id) 
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }
    }
}
