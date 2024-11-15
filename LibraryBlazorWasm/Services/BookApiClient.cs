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
            var bookNew = new BookVM()
            {
                BookName = bookCreateRequest.BookName,
                BookPrices = bookCreateRequest.BookPrices,
                ImgFile = bookCreateRequest.ImgFile,
                PublicationYear = bookCreateRequest.PublicationYear
            }; 

           var content = new StringContent(JsonConvert.SerializeObject(bookNew),
                System.Text.Encoding.UTF8, "Application/json");
            var authorIds = bookCreateRequest.AuthorIds;
            var genreIds = bookCreateRequest.GenreIds;
            if (authorIds != null && authorIds.Count > 0)
            {
                url += "?lstIdAuthor=" + string.Join("&lstIdAuthor=", authorIds);
            }
            var result = await _httpClient.PostAsync(url, content);
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
