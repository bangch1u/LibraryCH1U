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
            var book = _bookRepos.GetById(id);
            if (book != null)
            {
                _bookRepos.Delete(book);
                _bookRepos.Save();
                return true;
            }
            return false;
        }

        public List<Book> getAll()
        {
            return _bookRepos.GetAll();
        }

        public Book getById(Guid id)
        {
            return _bookRepos.GetById(id);
        }

        public bool updateBook(Guid id, BookVM book, List<Guid> lstIdAuthor)
        {
            var bookNow = _bookRepos.GetById(id);
            if (bookNow != null)
            {
                bookNow.BookName = book.BookName;
                bookNow.BookPrices = book.BookPrices;
                bookNow.ImgFile = book.ImgFile;
                List<Author> listAuthor = new List<Author>();
                foreach (Guid idAuthor in lstIdAuthor)
                {
                    var author = _authorRepos.GetById(idAuthor);
                    if (author != null)
                    {
                        listAuthor.Add(author);
                    }
                }
                bookNow.Authors = listAuthor;
              
                _bookRepos.Update(bookNow);
                _bookRepos.Save();
                return true;
            }
            return false;

        }
    }
}
