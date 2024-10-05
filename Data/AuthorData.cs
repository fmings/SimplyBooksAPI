using SimplyBooksAPI.Models;

namespace SimplyBooksAPI.Data
{
    public class AuthorData
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author {
                Id = 101,
                Email = "JonKrakaur@gmail.com",
                FirstName = "Jon",
                LastName = "Krakauer",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGVQKxyrpEB7paNWPsE1HENKWc5DO4YNA3yg&s",
                Favorite = false,
                UserId = 201,
            },

            new Author {
                Id = 102,
                Email = "NeilGaiman@gmail.com",
                FirstName = "Neil",
                LastName = "Gaiman",
                Image = "https://i.scdn.co/image/ab6761610000e5ebcea9cea935b24046a41876e5",
                Favorite = false,
                UserId = 201,
            },

            new Author {
                Id = 103,
                Email = "AnnNapolitano@gamil.com",
                FirstName = "Ann",
                LastName = "Napolitano",
                Image = "https://m.media-amazon.com/images/S/amzn-author-media-prod/i8b1efiukhi1enhp5idlc56pm1.jpg",
                Favorite = false,
                UserId = 201,
            },

            new Author {
                Id = 104,
                Email = "ColleenHoover@gmail.com",
                FirstName = "Colleen",
                LastName = "Hoover",
                Image = "https://img.texasmonthly.com/2024/05/colleen-hoover-1.jpg?auto=compress&crop=faces&fit=fit&fm=pjpg&ixlib=php-3.3.1&q=45",
                Favorite = true,
                UserId = 201,
            },

            new Author {
                Id = 105,
                Email = "JessicaKnoll@gmail.com",
                FirstName = "Jessica",
                LastName = "Knoll",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTliTAH4YXNHgiQlPEBwLINOGBnLQ018r0tIw&s",
                Favorite = true,
                UserId = 201,
            },
        };
    }
}
