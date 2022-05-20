using UserService.Model;

namespace UserService.Data
{
    public interface IDataRepository
    {
        List<User> AddUser(User user);
        User GetUserById(string id);
        List<User> GetUsers();
        User PutUser(User user);
    }
}