using LibraryData.DataTransferObjects;
using System.Net.Http.Json;

namespace LibraryBlazorWasm.Services
{
    public class GenreApiClient : IGenreApiClient
    {
        private readonly HttpClient _httpClient;

        public GenreApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GenreDto>> GetAllGenre()
        {
            return await _httpClient.GetFromJsonAsync<List<GenreDto>>("/api/genres");
        }
    }
}
