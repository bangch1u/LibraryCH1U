using LibraryAPI.Repositories;
using LibraryData.Models;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepos;
        private readonly IGenericRepository<Author> _authorRepos;
        private readonly IBookRepos _bookRepos2;
        private readonly IBookGenreService _bookGenreService;
        public BookService(IGenericRepository<Book> bookRepos,
            IGenericRepository<Author> authorRepos,
            IBookRepos bookRepos2,
            IBookGenreService bookGenreService)
        {
                _bookRepos = bookRepos;
            _authorRepos = authorRepos;
            _bookRepos2 = bookRepos2;
            _bookGenreService = bookGenreService;
        }

        public bool createBook(List<Guid> lstIdAuthor,BookVM book, List<Guid> lstIdGenre)
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
            bookNew.Genres = new List<BookGenre>();
            foreach (Guid idAuthor in lstIdAuthor)
            {
                var author = _authorRepos.GetById(idAuthor);
                if (author != null)
                {
                    bookNew.Authors.Add(author);
                }
            }
            foreach (Guid idGenre in lstIdGenre)
            {
                var genre = _bookGenreService.getById(idGenre);
                if (genre != null)
                {
                    bookNew.Genres.Add(genre);
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
            return _bookRepos2.getById(id);
        }

        public bool updateBook(Guid id, BookVM book, List<Guid> lstIdAuthor, List<Guid> lstIdGenre)
        {
            var bookNow = _bookRepos2.getById(id);
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
                List<BookGenre> listGenre = new List<BookGenre>();
                foreach (Guid idGenre in lstIdGenre)
                {
                    var genre = _bookGenreService.getById(idGenre);
                    if (genre != null)
                    {
                        listGenre.Add(genre);
                    }
                }
                bookNow.Genres = listGenre;
                bookNow.Authors = listAuthor;
              
                _bookRepos.Update(bookNow);
                _bookRepos.Save();
                return true;
            }
            return false;

        }
    }
}
