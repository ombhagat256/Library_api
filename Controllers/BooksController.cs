// Controllers/BooksController.cs
using LibraryApi.Models;
using LibraryApi.Models;
using LibraryApi.Repositories; // Corrected namespace
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BooksController()
        {
            _bookRepository = new BookRepository();
        }

        // GET api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = BookRepository.Books;  // Use the static Books property directly
            return Ok(books);
        }

        // GET api/books/{title}
        [HttpGet("{title}")]
        public IActionResult GetBooksByTitle(string title)
        {
            var books = BookRepository.Books.Where(b => b.Title.Contains(title)).ToList();
            if (!books.Any())
                return NotFound("No books found with the given title.");
            return Ok(books);
        }

        // POST api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (BookRepository.Books.Any(b => b.ISBN == book.ISBN))
                return Conflict("A book with the same ISBN already exists.");

            BookRepository.Books.Add(book);
            return CreatedAtAction(nameof(GetBooksByTitle), new { title = book.Title }, book);
        }

        // PUT api/books/{isbn}
        [HttpPut("{isbn}")]
        public IActionResult UpdateBook(string isbn, [FromBody] Book updatedBook)
        {
            var book = BookRepository.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
                return NotFound("Book not found.");

            // Update the book
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Available = updatedBook.Available;

            return NoContent();
        }

        // DELETE api/books/{isbn}
        [HttpDelete("{isbn}")]
        public IActionResult DeleteBook(string isbn)
        {
            var book = BookRepository.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
                return NotFound("Book not found.");

            BookRepository.Books.Remove(book);
            return NoContent();
        }
    }
}
