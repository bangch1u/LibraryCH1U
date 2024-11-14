using Azure;
using LibraryData.Models;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using X.PagedList.Extensions;

namespace LibraryView.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _httpClient;
        private  string url = "https://localhost:7026/api/Book";
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(HttpClient httpClient, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int? page, int? pageSize)
        {
            if(page == null)
            {
                page = 1;
            }
            if(pageSize == null)
            {
                pageSize = 5;
            }
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var lstBook = JsonConvert.DeserializeObject<List<Book>>(result);

                // Sử dụng ToPagedList từ X.PagedList để phân trang
                var pagedList = lstBook.ToPagedList((int)page, (int)pageSize);

                return View(pagedList);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Author> lstAuthor = new List<Author>(); // Khởi tạo danh sách rỗng

            var response = await _httpClient.GetAsync("https://localhost:7026/api/Author");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                lstAuthor = JsonConvert.DeserializeObject<List<Author>>(result);
            }

            var viewModel = new BookAuthorVM
            {
                Book = new Book(),
                Authors = lstAuthor // Gán danh sách tác giả vào ViewModel
            };

            return View(viewModel); ;
 
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book, IFormFile imageFile, string lstIdAuthor)
        {
            // Chuyển đổi chuỗi lstIdAuthor thành List<Guid>
            var authorIds = lstIdAuthor.Split(',').Select(Guid.Parse).ToList();

            // Gán ID cho sách
            book.BookId = Guid.NewGuid();

            if (imageFile != null && imageFile.Length > 0)
            {
                string newfilepath = Path.Combine(_webHostEnvironment.WebRootPath, "img");

                // Tạo tên tệp duy nhất để tránh ghi đè lên các tệp có cùng tên.
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(newfilepath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                book.ImgFile = "/img/" + uniqueFileName;
            }

            // Chuẩn bị nội dung JSON
            var content = new StringContent(JsonConvert.SerializeObject(book),
                System.Text.Encoding.UTF8, "application/json");

            // Thêm lstIdAuthor vào query string

            if (authorIds != null && authorIds.Count > 0)
            {
                url += "?lstIdAuthor=" + string.Join("&lstIdAuthor=", authorIds);
            }

            var response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var book = JsonConvert.DeserializeObject<Book>(result);

                return View(book);
            }
            return NotFound();
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(Book book, IFormFile imageFile, string lstIdAuthor)
        //{

        //}
        public async Task<IActionResult> deleteBook(Guid id)
        {
            var response = await _httpClient.DeleteAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Content("Loix");
        }
    }
}
