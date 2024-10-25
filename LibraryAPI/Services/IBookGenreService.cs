using LibraryData.Models;

namespace LibraryAPI.Services
{
    public interface IBookGenreService
    {
        List<BookGenre> getAll();
        BookGenre getById(Guid id);
        bool createBookGenre(BookGenre bookGenre);
        bool updateBookGenre(Guid id, BookGenre bookGenre);
        bool deleteBookGenre(Guid id);
    }
}
