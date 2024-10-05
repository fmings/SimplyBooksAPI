using SimplyBooksAPI.Data;
using SimplyBooksAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SimplyBooksAPI.API
{
    public class AuthorAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL AUTHORS
            app.MapGet("/authors", () => {
                return AuthorData.Authors.ToList();
            });

            // GET AUTHORS BY USERID
            app.MapGet("/{id}/authors", (int id) => {
                List<Author> authors = AuthorData.Authors.Where(a => a.UserId == id).ToList();

                return authors;

            });

            // GET SINGLE AUTHOR
            app.MapGet("/author/{id}", (int id) =>
            {
                Author author = AuthorData.Authors.FirstOrDefault(b => b.Id == id);

                if (author != null)
                {
                    List<Book> books = BookData.Books.Where(b => b.AuthorId == id).ToList();
                    author.Books = books;

                    return Results.Ok(author);
                }

                return Results.NotFound();
            });

            // CREATE A NEW AUTHOR
            app.MapPost("/author", (Author newAuthor) =>
            {
                newAuthor.Id = AuthorData.Authors.Max(a => a.Id) + 1;
                AuthorData.Authors.Add(newAuthor);
                return newAuthor;
            });

            // UPDATE AN AUTHOR
            app.MapPut("/author/{id}", (int id, Author updatedAuthor) =>
            {
                Author authorToUpdate = AuthorData.Authors.FirstOrDefault(a => a.Id == id);
                if (authorToUpdate == null)
                {
                    return Results.NotFound();
                }

                authorToUpdate.Email = updatedAuthor.Email;
                authorToUpdate.FirstName = updatedAuthor.FirstName;
                authorToUpdate.LastName = updatedAuthor.LastName;
                authorToUpdate.Image = updatedAuthor.Image;
                authorToUpdate.Favorite = updatedAuthor.Favorite;
                authorToUpdate.UserId = updatedAuthor.UserId;

                return Results.Ok(authorToUpdate);
            });

            // DELETE AN AUTHOR
            app.MapDelete("author/{id}", (int id) =>
            {
                List<Book> booksToDelete = BookData.Books.Where(b => b.AuthorId == id).ToList();
                foreach (Book book in booksToDelete)
                {
                    BookData.Books.Remove(book);
                }

                Author authorToDelete = AuthorData.Authors.FirstOrDefault(a => a.Id == id);
                if (authorToDelete == null)
                {
                    return Results.NotFound();
                }

                AuthorData.Authors.Remove(authorToDelete);

                return Results.NoContent();

            });
        }

    }
}
