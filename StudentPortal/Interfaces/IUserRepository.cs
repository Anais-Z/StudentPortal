using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
    }
}
