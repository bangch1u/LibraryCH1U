using LibraryData.DataTransferObjects;

namespace LibraryBlazorWasmAdmin.Services
{
    public interface IGenreManagerApiClient
    {
        Task<List<GenreDto>> GetAllGenre();
    }
}
