using LibraryAPI.Repositories;
using LibraryData.Data;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepos;

        public AuthorService(IGenericRepository<Author> authorRepos)
        {
            _authorRepos = authorRepos;
        }

        public bool createAuthor(Author author)
        {
            author.AuthorId = Guid.NewGuid();
            _authorRepos.Insert(author);
            return _authorRepos.Save();          
        }

        public bool deleteAuthor(Guid id)
        {
            var author = _authorRepos.GetById(id);
            if (author != null)
            {
                _authorRepos.Delete(author);
                return _authorRepos.Save();
            }
            return false;
        }

        public List<Author> getAll()
        {
            return _authorRepos.GetAll();
        }

        public Author getById(Guid id)
        {
            return _authorRepos.GetById(id);
        }

        public bool updateAuthor(Guid id, Author author)
        {
           var authorNow = _authorRepos.GetById(id);
            if(authorNow != null)
            {
                authorNow.AuthorName = author.AuthorName;
                authorNow.Birth = author.Birth; 
                _authorRepos.Update(authorNow);
                return _authorRepos.Save();
            }
            return false;
        }
    }
}
