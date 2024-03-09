using Tasks.Models;
namespace Tasks.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int Id);
        bool UserExists(int Id);
        bool RegisterUser(User user);
        string LoginUser(User user);
        bool Save();
    }
}
