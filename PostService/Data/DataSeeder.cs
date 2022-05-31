using PostService.Model;

namespace PostService.Data
{
    public class DataSeeder
    {
        private readonly PostDbContext postDbContext;

        public DataSeeder(PostDbContext postDbContext)
        {
            this.postDbContext = postDbContext;
        }

        public void Seed()
        {
            if (!postDbContext.Post.Any())
            {
                var posts = new List<Post>()
                {
                    new Post()
                    {
                        Id = "0",
                        UserId = "0",
                        Body = "New Twooter who dis?"
                    },
                    new Post()
                    {
                        Id = "1",
                        UserId = "0",
                        Body = "When is Twooter gonna implement picture uploads?"
                    },
                    new Post()
                    {
                        Id = "2",
                        UserId = "2",
                        Body = "Got twooter recommended by Pieter"
                    },
                    new Post()
                    {
                        Id = "2",
                        UserId = "2",
                        Body = "https://www.youtube.com/watch?v=eX2qFMC8cFo"
                    },
                    new Post()
                    {
                        Id = "2",
                        UserId = "2",
                        Body = "Why doesn't twooter allow video embedds???"
                    }

                };

                postDbContext.Post.AddRange(posts);
                postDbContext.SaveChanges();
            }
        }
    }
}