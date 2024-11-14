using LibraryAPI.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Models;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private List<string> NA = new List<string> { "N/A" };
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var lstBook = _service.getAll();            
            if (lstBook != null)
            {
                var bookDto = lstBook.Select(x => new BookDto()
                {
                    BookId = x.BookId,
                    BookName = x.BookName,
                    BookPrices = x.BookPrices,
                    ImgFile = x.ImgFile != null ? x.ImgFile : "N/A" ,
                    AuthorNames = x.Authors != null && x.Authors.Count > 0 ? x.Authors.Select(a => a.AuthorName).ToList() : NA,
                    PublicationYear = x.PublicationYear,
                    Genres = x.Genres != null && x.Genres.Count > 0 ? x.Genres.Select(g => g.GenreName).ToList() : NA,
                });
                return Ok(bookDto);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult getBook(Guid id)
        {
            var book = _service.getById(id);
            if (book != null)
            {
                return Ok(new BookDto() {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    BookPrices = book.BookPrices,
                    ImgFile = book.ImgFile != null ? book.ImgFile : "N/A",
                    AuthorNames = book.Authors != null && book.Authors.Count > 0 ? book.Authors.Select(a => a.AuthorName).ToList() : NA,
                    PublicationYear = book.PublicationYear,
                    Genres = book.Genres != null && book.Genres.Count > 0 ? book.Genres.Select(g => g.GenreName).ToList() : NA,
                });

            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult createBook([FromQuery] List<Guid> lstIdAuthor, [FromBody] BookVM book, [FromQuery] List<Guid> lstIdGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookNew = _service.createBook(lstIdAuthor, book, lstIdGenre);
       
                return StatusCode(201, book);
           
        }
        [HttpPut("{id}")]
        public IActionResult updateBook(Guid id, [FromBody] BookVM book, [FromQuery] List<Guid> lstIdAuthor, [FromQuery] List<Guid> lstIdGenre)
        {
            var bookNew = _service.updateBook(id, book, lstIdAuthor, lstIdGenre);
            return StatusCode(200, book);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteBook(Guid id)
        {
            if (_service.deleteBook(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
