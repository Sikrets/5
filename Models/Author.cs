using System.Collections.Generic;

namespace AsyncLibraryApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
