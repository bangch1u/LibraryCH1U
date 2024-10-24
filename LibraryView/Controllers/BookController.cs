using LibraryData.Models;
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
        private readonly string url = "https://localhost:7026/api/Book";
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book, IFormFile imageFile)
        {
            book.BookId = Guid.NewGuid();
            ////xây dựng 1 đường dẫn để lưu ảnh 
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
            ////Tao 1 đối tượng FileStream để ghi dữ liệu vào file mới tại vừa tạo
            //var stream = new FileStream(path, FileMode.Create);
            ////sao chép hình ảnh vào thư mục root
            //imageFile.CopyTo(stream);
            ////gán tên file ảnh cho thuộc tính 
            //book.ImgFile = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0)
            {
                string newfilepath = Path.Combine(_webHostEnvironment.WebRootPath, "img");

                // Tạo tên tệp duy nhất để tránh ghi đè lên các tệp có cùng tên.
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(newfilepath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                book.ImgFile = "/img/" + uniqueFileName;
            }
           
            var Content = new StringContent(JsonConvert.SerializeObject(book), 
                System.Text.Encoding.UTF8, "Application/json");
            var response = await _httpClient.PostAsync(url, Content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
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
