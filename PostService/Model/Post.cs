namespace PostService.Model
{
    public class Post
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public String Body { get; set; }
        public DateTime CreatedDate { get; private set; }

        public Post()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
