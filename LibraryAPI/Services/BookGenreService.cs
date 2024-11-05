using LibraryAPI.Repositories;
using LibraryData.Models;

namespace LibraryAPI.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IGenericRepository<BookGenre> _bookGenreRepos;
        public BookGenreService(IGenericRepository<BookGenre> bookGenreRepos)
        {
            _bookGenreRepos = bookGenreRepos; 
        }

        public void createBookGenre(BookGenre bookGenre)
        {
            bookGenre.Id = Guid.NewGuid();
            _bookGenreRepos.Insert(bookGenre);
            _bookGenreRepos.Save();
        }

        public void deleteBookGenre(Guid id)
        {
            _bookGenreRepos.Delete(getById(id));
            _bookGenreRepos.Save();
        }

        public List<BookGenre> getAll()
        {
            return _bookGenreRepos.GetAll();
        }

        public BookGenre getById(Guid id)
        {
            return _bookGenreRepos.GetById(id);
        }

        public void updateBookGenre(Guid id, BookGenre bookGenre)
        {
            var bgNow = _bookGenreRepos.GetById(id);
            if (bgNow != null)
            {
                bgNow.GenreName = bookGenre.GenreName;
                bgNow.AgeLimit = bookGenre.AgeLimit;
                _bookGenreRepos.Update(bgNow);
                _bookGenreRepos.Save();
            }
            
        }
    }
}
