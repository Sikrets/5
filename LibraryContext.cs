using AsyncLibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncLibraryApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AsyncLibraryDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(e =>
            {
                e.ToTable("Authors");
                e.HasKey(a => a.Id);
                e.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(e =>
            {
                e.ToTable("Books");
                e.HasKey(b => b.Id);
                e.Property(b => b.Title).IsRequired().HasMaxLength(200);

                e.HasOne(b => b.Author)
                 .WithMany(a => a.Books)
                 .HasForeignKey(b => b.AuthorId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            var authors = new List<Author>();
            var books = new List<Book>();
            int bookId = 1;

            string[] names = {
                "Taras Shevchenko", "Lesya Ukrainka", "Ivan Franko",
                "George Orwell", "Ernest Hemingway", "Fyodor Dostoevsky",
                "Mark Twain", "Agatha Christie", "Stephen King", "J.K. Rowling"
            };

            for (int i = 0; i < names.Length; i++)
            {
                authors.Add(new Author { Id = i + 1, FullName = names[i] });

                for (int j = 1; j <= 10; j++)
                {
                    books.Add(new Book
                    {
                        Id = bookId++,
                        Title = $"{names[i].Split(' ')[0]} Book {j}",
                        Year = 1900 + (i * 10) + j,
                        AuthorId = i + 1
                    });
                }
            }

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);

            base.OnModelCreating(modelBuilder);
        }
    }
}
