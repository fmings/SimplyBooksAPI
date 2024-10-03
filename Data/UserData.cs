using SimplyBooksAPI.Models;

namespace SimplyBooksAPI.Data
{
    public class UserData
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = "201",
                FirstName = "Felicia",
                LastName = "Mings",
                Email = "mingsfelicia@gmail.com",
            },
        };
    }
}
