using LibraryAPI.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult getAllAuthors()
        {
            var lstAuthor = _service.getAll();
            if (lstAuthor != null)
            {
                return Ok(lstAuthor.Select(x => new AuthorDto()
                {
                    Id = x.AuthorId,
                    Name = x.AuthorName
                }));
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult getAuthor(Guid id)
        {
            var author = _service.getById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult createAuthor(Author author)
        {
            var status = _service.createAuthor(author);
            if (status)
            {
                return StatusCode(201, author);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult updateAuthor(Guid id,Author author)
        {
            var status = _service.updateAuthor(id,author);
            if (status)
            {
                return StatusCode(200, author);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult deleteAuthor(Guid id)
        {
            var status = _service.deleteAuthor(id);
            if (status)
            {
                return StatusCode(200);
            }
            return BadRequest();
        }
    }
}
