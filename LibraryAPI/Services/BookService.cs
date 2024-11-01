using LibraryAPI.Repositories;
using LibraryData.Models;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepos;
        private readonly IGenericRepository<Author> _authorRepos;
        public BookService(IGenericRepository<Book> bookRepos,
            IGenericRepository<Author> authorRepos)
        {
                _bookRepos = bookRepos;
            _authorRepos = authorRepos;
        }

        public bool createBook(List<Guid> lstIdAuthor,BookVM book)
        {
            var bookNew = new Book()
            {
                BookId = Guid.NewGuid(),
                BookName = book.BookName,
                BookPrices = book.BookPrices,
                ImgFile = book.ImgFile,
                PublicationYear = book.PublicationYear
            };
           
            bookNew.Authors = new List<Author>();
            foreach (Guid idAuthor in lstIdAuthor)
            {
                var author = _authorRepos.GetById(idAuthor);
                if (author != null)
                {
                    bookNew.Authors.Add(author);
                }
            }
          


            _bookRepos.Insert(bookNew);
            return _bookRepos.Save();
           
        }

        public bool deleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Book> getAll()
        {
            throw new NotImplementedException();
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
