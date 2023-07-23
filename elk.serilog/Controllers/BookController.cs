using elk.serilog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using System.Xml.Linq;

namespace elk.serilog.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> books = new List<Book>() {
        new Book() { Id = 1, Name = "Ballokal", AuthorId = 1 },
        new Book() { Id = 2, Name = "Gollachut", AuthorId = 2 },
        new Book() { Id = 3, Name = "Nodi", AuthorId = 1 }};

        public BookController()
        {

        }

        [HttpPost("add-book")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Name))
                    throw new NullReferenceException($"Book name required");


                Log.Information($"Adding new book in the book list {book.Name}");

                books.Add(book);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            try
            {
                if (books.Count() == 0)
                    throw new NullReferenceException($"No books found in the list");


                Log.Information($"Adding new book in the book list {books}");

                return Ok(books);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("delete-all-book")]
        public IActionResult DeleteAllBook()
        {
            try
            {
                if (books.Count() == 0)
                    throw new NullReferenceException($"No books found in the list to delete");

                books.Clear();
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest();
            }
        }

        //public override string ToString()
        //{
        //    return string.Join(',', books);
        //}

    }
}
