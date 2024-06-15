using BookCatalog.Application.Interfaces;
using BookCatalog.Data;
using BookCatalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Application.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookCatalogContext bookCatalogContext;

        public BookRepository(BookCatalogContext bookCatalog) 
        {
            bookCatalogContext = bookCatalog;
        }

        public async Task AddBooks(Book book)
        {
            bookCatalogContext.Add(book);
            await bookCatalogContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await bookCatalogContext.Books.ToListAsync();
            return books;
        }

        public async Task<Book?>GetBookById(int id)
        {
            var book = await bookCatalogContext.Books.FirstOrDefaultAsync(e => e.Id == id);
            return book;
        }

        public async Task UpdateBook(Book book)
        {
            var existingBook = await bookCatalogContext.Books.FindAsync(book.Id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.Category = book.Category;
                await bookCatalogContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = await GetBookById(id);
            if(book is not null)
            {
                bookCatalogContext.Books.Remove(book);
                await bookCatalogContext.SaveChangesAsync();
            }
        }

    }
}
