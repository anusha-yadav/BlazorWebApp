using BookCatalog.Data.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task AddBooks(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
