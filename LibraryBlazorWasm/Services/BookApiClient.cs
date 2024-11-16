using LibraryData.DataTransferObjects;
using LibraryData.Request;
using LibraryData.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace LibraryBlazorWasm.Services
{
    public class BookApiClient : IBookApiClient
    {
        private readonly HttpClient _httpClient;
        private string url = "/api/books";
        public BookApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBook(BookCreateRequest bookCreateRequest)
        {
            // Khởi tạo BookVM từ bookCreateRequest
            var bookNew = new BookVM()
            {
                BookName = bookCreateRequest.BookName,
                BookPrices = bookCreateRequest.BookPrices,
                ImgFile = "string",
                PublicationYear = bookCreateRequest.PublicationYear
            };

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

            // Sử dụng PostAsJsonAsync để gửi BookVM
            var response = await _httpClient.PostAsJsonAsync(urlWithQuery, bookNew);

            // Kiểm tra kết quả trả về
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Book created successfully");
                // Đọc nội dung từ response và in ra
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
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
            }
        }



        public async Task<List<BookDto>> GetAllBook()
        {
            var result = await _httpClient.GetFromJsonAsync<List<BookDto>>(url);
            return result;
        }

        public async Task<BookDto> GetBook(Guid id)
        {
            var book  = await _httpClient.GetFromJsonAsync<BookDto>($"/api/books/{id}");
            return book;
        }
        
    }
}
