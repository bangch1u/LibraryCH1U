using LibraryData.DataTransferObjects;
using System.Net.Http.Json;

namespace LibraryBlazorWasmAdmin.Services
{
    public class AuthorManagerApiClient : IAuthorManagerApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthorManagerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        string url = "/api/authors";
        public async Task<List<AuthorDto>> GetAllAuthor()
        {
            return await _httpClient.GetFromJsonAsync<List<AuthorDto>>(url);
        }
    }
}
