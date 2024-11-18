using LibraryData.Data;

namespace LibraryAPI.Repositories
{
    public interface IAuthorRepos
    {
        List<Author> getAll();
        Author getById(Guid id);
        bool createAuthor(Author author);
        bool updateAuthor(Guid id, Author author);
        bool deleteAuthor(Guid id);
    }
}
