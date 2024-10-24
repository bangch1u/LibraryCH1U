using LibraryAPI.Repositories;
using LibraryData.Models;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepos _repos;
        public BookService(IBookRepos repos)
        {
                _repos = repos;
        }

        public bool createBook(Book book)
        {
            return _repos.createBook(book);
        }

        public bool deleteBook(Guid id)
        {
            return _repos.deleteBook(id);
        }

        public List<Book> getAll()
        {
           return _repos.getAll();
        }

        public Book getById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool updateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
