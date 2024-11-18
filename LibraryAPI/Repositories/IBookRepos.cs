using LibraryData.Data;

namespace LibraryAPI.Repositories
{
    public interface IBookRepos
    {
        List<Book> getAll();
        Book getById(Guid id);
        bool createBook(Book book);
        bool updateBook(Guid id,Book book);
        bool deleteBook(Guid id);

    }
}
