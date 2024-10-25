using LibraryData.Context;
using LibraryData.Models;

namespace LibraryAPI.Repositories
{
    public class BookGenreRepos : IBookGenreRepos
    {
        private readonly LibraryContext _context;

        public BookGenreRepos(LibraryContext context)
        {
            _context = context;
        }

        public bool createBookGenre(BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }

        public bool deleteBookGenre(Guid id)
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

        public bool updateBookGenre(Guid id, BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }
    }
}
