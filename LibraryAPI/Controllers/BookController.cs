using LibraryAPI.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Data;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private List<string> NA = new List<string> { "N/A" };
        private readonly IWebHostEnvironment _env;
        public BookController(IBookService service,
            IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
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
                    ImgFile = x.ImgFile != null ? $"{Request.Scheme}://{Request.Host}/Uploads/{x.ImgFile}" : "N/A" ,
                    AuthorNames = x.Authors != null && x.Authors.Count > 0 ? x.Authors.Select(a => a.AuthorName).ToList() : NA,
                    PublicationYear = x.PublicationYear,
                    Genres = x.Genres != null && x.Genres.Count > 0 ? x.Genres.Select(g => g.GenreName).ToList() : NA,
                });
                return Ok(bookDto);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult getBook([FromRoute]Guid id)
        {
            var book = _service.getById(id);
            if (book != null)
            {
                return Ok(new BookDto() {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    BookPrices = book.BookPrices,
                    ImgFile = book.ImgFile != null ? $"{Request.Scheme}://{Request.Host}/Uploads/{book.ImgFile}" : "N/A",
                    AuthorNames = book.Authors != null && book.Authors.Count > 0 ? book.Authors.Select(a => a.AuthorName).ToList() : NA,
                    PublicationYear = book.PublicationYear,
                    Genres = book.Genres != null && book.Genres.Count > 0 ? book.Genres.Select(g => g.GenreName).ToList() : NA,
                });

            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult createBook([FromQuery] List<Guid> lstIdAuthor, [FromForm] BookVM book, [FromQuery] List<Guid> lstIdGenre,[FromForm] IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string trustedFileNameForFileStorage;
            var untrustedFileName = imageFile.FileName;
            string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);//mã hóa tên file 

            trustedFileNameForFileStorage = Path.GetRandomFileName();
            if (imageFile != null && imageFile.Length > 0)
            {
                // Lấy phần mở rộng của tệp gốc
                var fileExtension = Path.GetExtension(imageFile.FileName);

                // Tạo tên tệp mới và đảm bảo có phần mở rộng
                trustedFileNameForFileStorage = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);

                string newFilePath = Path.Combine(uploadsFolder, trustedFileNameForFileStorage);
                using (FileStream fs = new(newFilePath, FileMode.Create))
                {
                    imageFile.CopyTo(fs);
                }

                book.ImgFile = trustedFileNameForFileStorage;
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
