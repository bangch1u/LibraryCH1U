using LibraryData.DataTransferObjects;
using LibraryData.Request;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LibraryBlazorWasmAdmin.Services
{
    public class BookMangerApiClient : IBookManagerApiClient
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;
        public BookMangerApiClient(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        private string url = "/api/books";
        public async Task CreateBook(BookCreateRequest bookCreateRequest)
        {
            var content = new MultipartFormDataContent();
            // Khởi tạo BookVM từ bookCreateRequest
            var bookNew = new BookVM()
            {
                BookName = bookCreateRequest.BookName,
                BookPrices = bookCreateRequest.BookPrices,
                ImgFile = "string",
                PublicationYear = bookCreateRequest.PublicationYear
            };
            // Thêm các thông tin sách vào MultipartFormDataContent
            content.Add(new StringContent(bookCreateRequest.BookName ?? ""), "BookName");
            content.Add(new StringContent(bookCreateRequest.BookPrices.ToString()), "BookPrices");
            content.Add(new StringContent(bookCreateRequest.PublicationYear.ToString()), "PublicationYear");
            // Xây dựng query string cho các ID tác giả và thể loại
            var queryParameters = new List<string>();

            if (bookCreateRequest.AuthorIds != null && bookCreateRequest.AuthorIds.Count > 0)
            {
                queryParameters.Add("lstIdAuthor=" + string.Join("&lstIdAuthor=", bookCreateRequest.AuthorIds));
            }

            if (bookCreateRequest.GenreIds != null && bookCreateRequest.GenreIds.Count > 0)
            {
                queryParameters.Add("lstIdGenre=" + string.Join("&lstIdGenre=", bookCreateRequest.GenreIds));
            }

            string urlWithQuery = url;
            if (queryParameters.Count > 0)
            {
                urlWithQuery += "?" + string.Join("&", queryParameters);
            }
            // Đọc stream với kích thước tối đa là 5 MB (5 * 1024 * 1024 bytes)
            var fileContent = new StreamContent(bookCreateRequest.ImgFile.OpenReadStream(5 * 1024 * 1024))
            {
                Headers = { ContentType = new MediaTypeHeaderValue("image/jpeg") }
            };

            content.Add(fileContent, "imageFile", bookCreateRequest.ImgFile.Name);

            //content.Add(new StringContent(JsonConvert.SerializeObject(bookNew), System.Text.Encoding.UTF8, "application/json"), "book");
            // Sử dụng PostAsJsonAsync để gửi BookVM
            var response = await _httpClient.PostAsync(urlWithQuery, content);

            // Kiểm tra kết quả trả về
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Book created successfully");
                // Đọc nội dung từ response và in ra
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                Console.WriteLine(bookCreateRequest.ImgFile.Name);
                _navigationManager.NavigateTo("/book/list");
            }
            else
            {
                Console.WriteLine(url);
                Console.WriteLine(bookNew.BookName);
                Console.WriteLine(bookNew.BookPrices);
                foreach (var item in bookCreateRequest.AuthorIds)
                {
                    Console.WriteLine(item);
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Failed to create book: " + response.StatusCode);
                Console.WriteLine("Error details: " + errorContent);
                Console.WriteLine(bookCreateRequest.ImgFile.Name);
            }
        }

        public async Task<List<BookDto>> GetAllBook()
        {
            var result = await _httpClient.GetFromJsonAsync<List<BookDto>>(url);
            return result;
        }

        public async Task<BookDto> GetBook(Guid id)
        {
            var book = await _httpClient.GetFromJsonAsync<BookDto>($"/api/books/{id}");
            return book;
        }
        public async Task DeleteBook(Guid id)
        {
            var response = await _httpClient.DeleteAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete Success!");
                _navigationManager.NavigateTo("/book/list");
            }
            else
            {
                Console.WriteLine("Fail!");
            }
        }
        
    }
}
