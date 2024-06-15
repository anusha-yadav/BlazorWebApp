using BookCatalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext(DbContextOptions<BookCatalogContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
