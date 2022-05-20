using PostService.Model;

namespace PostService.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly PostDbContext db;

        public DataRepository(PostDbContext db)
        {
            this.db = db;
        }

        public List<Post> GetPosts() => db.Post.ToList();

        public Post PutPost(Post user)
        {
            db.Post.Update(user);
            db.SaveChanges();
            return db.Post.Where(x => x.Id == user.Id).FirstOrDefault();
        }

        public List<Post> AddPost(Post user)
        {
            db.Post.Update(user);
            db.SaveChanges();
            return db.Post.ToList();
        }

        public Post GetPostById(string id)
        {
            return db.Post.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}