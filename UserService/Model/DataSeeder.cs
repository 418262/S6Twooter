namespace UserService.Model
{
    public class DataSeeder
    {
        private readonly UserDbContext userDbContext;

        public DataSeeder(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Seed()
        {
            if (!userDbContext.User.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Id = "0",
                        Name = "Pieter"
                    },
                    new User()
                    {
                        Id = "1",
                        Name = "Edoardo"
                    },
                    new User()
                    {
                        Id = "2",
                        Name = "Gradus"
                    },
                    new User()
                    {
                        Id = "3",
                        Name = "Keyleigh"
                    },
                    new User()
                    {
                        Id = "4",
                        Name = "Niklas"
                    }

                };

                userDbContext.User.AddRange(users);
                userDbContext.SaveChanges();
            }
        }
    }
}
