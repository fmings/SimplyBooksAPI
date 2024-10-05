using SimplyBooksAPI.Data;
using SimplyBooksAPI.Models;

namespace SimplyBooksAPI.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // GET SINGLE USER
            app.MapGet("/user/{id}", (int id) =>
            {
                User user = UserData.Users.FirstOrDefault(b => b.Id == id);

                if (user == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(user);
                
            });
        }
    }
}
