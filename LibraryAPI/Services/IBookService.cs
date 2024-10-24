using LibraryData.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        List<Book> getAll();
        Book getById(Guid id);
        bool createBook(Book book);
        bool updateBook(Guid id, Book book);
        bool deleteBook(Guid id);
    }
}
