using LibraryAPI.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class BookGenerController : ControllerBase
    {
        private readonly IBookGenreService _service;
        public BookGenerController(IBookGenreService service)
        {
                _service = service;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var listGenre = _service.getAll();
            if (listGenre != null)
            {
                return Ok(listGenre.Select(x => new GenreDto()
                {
                    id = x.Id,
                    NameGenre = x.GenreName
                }));
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult getGenre(Guid id)
        {
            var genre = _service.getById(id);
            if(genre != null)
            {
                return Ok(genre);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult createGenre(BookGenre genre)
        {
            _service.createBookGenre(genre);
            return StatusCode(201,genre);
        }
        [HttpPut("{id}")]
        public IActionResult editGenre(Guid id,BookGenre genre)
        {
            _service.updateBookGenre(id, genre);
            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteGenre(Guid id)
        {
            _service.deleteBookGenre(id);
            return Ok();
        }
        
    }
}
