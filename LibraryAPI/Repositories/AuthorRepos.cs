using LibraryData.Context;
using LibraryData.Data;

namespace LibraryAPI.Repositories
{
    public class AuthorRepos : IAuthorRepos
    {
        private readonly LibraryContext _context;

        public AuthorRepos(LibraryContext context)
        {
            _context = context;
        }

        public bool createAuthor(Author author)
        {
            try
            {
                _context.Authors.Add(author);

                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool deleteAuthor(Guid id)
        {
            try
            {
                var author = _context.Authors.Find(id);
                if (author != null)
                {
                    _context.Authors.Remove(author);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;

            }
        }

        public List<Author> getAll()
        {
            try
            {
                return _context.Authors.ToList();
            }
            catch
            {

                return null;
            }
        }

        public Author getById(Guid id)
        {
            try
            {
                var author = _context.Authors.Find(id);
                if (author != null)
                {
                    return author;
                }
                return null;
            }
            catch
            {

                return null;
            }
        }

        public bool updateAuthor(Guid id, Author author)
        {
            try
            {
                var currentAuthor = _context.Authors.Find(id);
                if (author != null)
                {
                    currentAuthor.AuthorName = author.AuthorName;
                    currentAuthor.Birth = author.Birth;
                    _context.Authors.Update(currentAuthor);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }
    }
}
