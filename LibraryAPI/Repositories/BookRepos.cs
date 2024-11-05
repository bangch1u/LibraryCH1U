using LibraryData.Context;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class BookRepos : IBookRepos
    {
        private readonly LibraryContext _context;

        public BookRepos(LibraryContext context)
        {
            _context = context;
        }

        public bool createBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
                
            }
        }

        public bool deleteBook(Guid id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
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

        public List<Book> getAll()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch
            {

                return null;
            }
        }

        public Book getById(Guid id)
        {
            return _context.Books.Include("Authors").FirstOrDefault(e => e.BookId == id);
        }

        public bool updateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
