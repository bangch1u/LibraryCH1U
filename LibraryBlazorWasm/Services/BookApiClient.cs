using LibraryData.DataTransferObjects;
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

        public async Task<List<BookDto>> GetAllBook()
        {
            var result = await _httpClient.GetFromJsonAsync<List<BookDto>>(url);
            return result;
        }

        public async Task<BookDto> GetBook(Guid id)
        {
            var book  = await _httpClient.GetFromJsonAsync<BookDto>(url + $"/{id}");
            return book;
        }
    }
}
