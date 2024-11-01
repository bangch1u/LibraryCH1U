using LibraryData.Models;

namespace LibraryAPI.Services
{
    public interface IBookGenreService
    {
        List<BookGenre> getAll();
        BookGenre getById(Guid id);
        void createBookGenre(BookGenre bookGenre);
        void updateBookGenre(Guid id, BookGenre bookGenre);
        void deleteBookGenre(Guid id);
    }
}
