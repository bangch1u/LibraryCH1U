using LibraryData.Models;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        List<Book> getAll();
        Book getById(Guid id);
        bool createBook(List<Guid> lstIdAuthor, BookVM book);
        bool updateBook(Guid id, BookVM book);
        bool deleteBook(Guid id);
    }
}
