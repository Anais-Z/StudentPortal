using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(string firstName, string lastName);

        bool UserExists(int id);
    }
}
