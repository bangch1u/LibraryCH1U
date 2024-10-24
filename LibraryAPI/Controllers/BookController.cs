using LibraryAPI.Services;
using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
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
                return  Ok(lstBook);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult createBook(Book book)
        {
           
            var bookNew = _service.createBook(book);
            if (bookNew == true)
            {
                return StatusCode(201, book);
            }
            return BadRequest();
     
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
