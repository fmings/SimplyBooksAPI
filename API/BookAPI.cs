using SimplyBooksAPI.Models;
using SimplyBooksAPI.Data;
using static System.Net.Mime.MediaTypeNames;
namespace SimplyBooksAPI.API
{
    public class BookAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL BOOKS
            app.MapGet("/books", () => {
                return BookData.Books.ToList();
            });

            // GET BOOKS BY USERID
            app.MapGet("/{id}/books", (int id) => {
                List<Book> books = BookData.Books.Where(a => a.UserId == id).ToList();

                return books;

            });

            // GET SINGLE BOOK
            app.MapGet("/book/{id}", (int id) =>
            {
                Book book = BookData.Books.FirstOrDefault(b => b.Id == id);

                if (book != null)
                {
                    book.Author = AuthorData.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

                    return Results.Ok(book);
                }

                return Results.NotFound();
            });

            // CREATE A NEW BOOK
            app.MapPost("/book", (Book newBook) =>
            {
                newBook.Id = BookData.Books.Max(b => b.Id) + 1;
                BookData.Books.Add(newBook);
                return newBook;
            });

            // UPDATE A BOOK
            app.MapPut("/book/{id}", (int id, Book updatedBook) =>
            {
                Book bookToUpdate = BookData.Books.FirstOrDefault(b => b.Id == id);
                if (bookToUpdate == null)
                {
                    return Results.NotFound();
                }

                bookToUpdate.AuthorId = updatedBook.AuthorId;
                bookToUpdate.Title = updatedBook.Title;
                bookToUpdate.Image = updatedBook.Image;
                bookToUpdate.Description = updatedBook.Description;
                bookToUpdate.Price = updatedBook.Price;
                bookToUpdate.Sale = updatedBook.Sale;
                bookToUpdate.UserId = updatedBook.UserId;

                return Results.Ok(bookToUpdate);
            });

            // DELETE A BOOK
            app.MapDelete("book/{id}", (int id) =>
            {
                Book bookToDelete = BookData.Books.FirstOrDefault(b => b.Id == id);
                BookData.Books.Remove(bookToDelete);
                return Results.NoContent();
            });
        }
    }
}
