
namespace UserService.Model
{
    public interface IDataRepository
    {
        List<User> AddUser(User user);
        List<User> GetUsers();
        User PutUser(User user);
        User GetUserById(string id);
    }
}