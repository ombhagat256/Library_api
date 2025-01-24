using LibraryApi.Models;
using LibraryApi.Models;
using System.Collections.Generic;

namespace LibraryApi.Repositories
{
    public class BookRepository
    {
        // In-memory list of books, initialized with some sample data
        public static List<Book> Books = new List<Book>()
        {
            new Book { ISBN = "978-0131103627", Title = "The C Programming Language", Author = "Brian W. Kernighan, Dennis M. Ritchie", Available = true },
            new Book { ISBN = "978-0201633610", Title = "Design Patterns", Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", Available = false },
            new Book { ISBN = "978-0132350884", Title = "Clean Code", Author = "Robert C. Martin", Available = true }
        };
    }
}
