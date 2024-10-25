using LibraryAPI.Repositories;
using LibraryData.Models;

namespace LibraryAPI.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IBookGenreRepos _repos;
        public BookGenreService(IBookGenreRepos repos)
        {
                _repos = repos; 
        }
        public bool createBookGenre(BookGenre bookGenre)
        {
           return _repos.createBookGenre(bookGenre);
        }

        public bool deleteBookGenre(Guid id)
        {
            return _repos.deleteBookGenre(id);
        }

        public List<BookGenre> getAll()
        {
            return _repos.getAll();
        }

        public BookGenre getById(Guid id)
        {
            return _repos.getById(id);
        }

        public bool updateBookGenre(Guid id, BookGenre bookGenre)
        {
            return _repos.updateBookGenre(id, bookGenre);   
        }
    }
}
