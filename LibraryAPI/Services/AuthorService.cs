using LibraryAPI.Repositories;
using LibraryData.Models;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepos _repos;

        public AuthorService(IAuthorRepos repos)
        {
            _repos = repos;
        }

        public bool createAuthor(Author author)
        {
            return _repos.createAuthor(author);
        }

        public bool deleteAuthor(Guid id)
        {
           return _repos.deleteAuthor(id);
        }

        public List<Author> getAll()
        {
            return _repos.getAll();
        }

        public Author getById(Guid id)
        {
            return _repos.getById(id);
        }

        public bool updateAuthor(Guid id, Author author)
        {
            return _repos.updateAuthor(id, author); 
        }
    }
}
