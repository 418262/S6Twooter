using PostService.Model;

namespace PostService.Data
{
    public interface IDataRepository
    {
        List<Post> AddPost(Post user);
        Post GetPostById(string id);
        List<Post> GetPosts();
        Post PutPost(Post user);
    }
}