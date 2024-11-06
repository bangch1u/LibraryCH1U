using LibraryAPI.Services;
using LibraryData.Models;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

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
                return Ok(lstBook);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult getBook(Guid id)
        {
            var book = _service.getById(id);
            if (book != null)
            {
                return Ok(book);
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
