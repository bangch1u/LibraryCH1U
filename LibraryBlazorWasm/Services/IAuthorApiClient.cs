using LibraryData.DataTransferObjects;

namespace LibraryBlazorWasm.Services
{
    public interface IAuthorApiClient
    {
        Task<List<AuthorDto>> GetAllAuthor();
    }
}
