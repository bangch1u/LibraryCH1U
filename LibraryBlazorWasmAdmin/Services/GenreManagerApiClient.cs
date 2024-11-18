using LibraryData.DataTransferObjects;
using System.Net.Http.Json;

namespace LibraryBlazorWasmAdmin.Services
{
    public class GenreManagerApiClient : IGenreManagerApiClient
    {
        private readonly HttpClient _httpClient;

        public GenreManagerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GenreDto>> GetAllGenre()
        {
            return await _httpClient.GetFromJsonAsync<List<GenreDto>>("/api/genres");
        }
    }
}
