using LibraryData.DataTransferObjects;
using System.Net.Http.Json;

namespace LibraryBlazorWasm.Services
{
    public class AuthorApiClient : IAuthorApiClient
    {
        private readonly HttpClient _httpClient;
        string url = "/api/authors";
        public AuthorApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AuthorDto>> GetAllAuthor()
        {
            return await _httpClient.GetFromJsonAsync<List<AuthorDto>>(url);
        }
    }
}
