using LibraryData.Models;

namespace LibraryAPI.Repositories
{
    public interface IBookGenreRepos
    {
        List<BookGenre> getAll();
        BookGenre getById(Guid id);
        bool createBookGenre(BookGenre bookGenre);
        bool updateBookGenre(Guid id, BookGenre bookGenre);
        bool deleteBookGenre(Guid id);  
    }
}
