using LibraryData.DataTransferObjects;

namespace LibraryBlazorWasm.Services
{
    public interface IGenreApiClient
    {
        Task<List<GenreDto>> GetAllGenre();
    }
}
