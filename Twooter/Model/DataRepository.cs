namespace Twooter.Model
{
    public class DataRepository : IDataRepository
    {
        private readonly UserDbContext db;

        public DataRepository(UserDbContext db)
        {
            this.db = db;
        }

        public List<User> GetUsers() => db.User.ToList();

        public User PutUser(User user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.Id == user.Id).FirstOrDefault();
        }

        public List<User> AddUser(User user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.ToList();
        }

        public User GetUserById(string id)
        {
            return db.User.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
