using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(string firstName, string lastName);

        User GetUserById(int id);

        bool CreateUser(User user);

        bool UserExists(int id);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

    }
}
