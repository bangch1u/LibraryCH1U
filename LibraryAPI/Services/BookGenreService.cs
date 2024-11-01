using LibraryAPI.Repositories;
using LibraryData.Models;

namespace LibraryAPI.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IGenericRepository<Book> _bookRepos;
        public BookGenreService(IGenericRepository<Book> bookReposs)
        {
            _bookRepos = bookReposs; 
        }

        public void createBookGenre(BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }

        public void deleteBookGenre(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BookGenre> getAll()
        {
            throw new NotImplementedException();
        }

        public BookGenre getById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void updateBookGenre(Guid id, BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }
    }
}
