using LibraryData.DataTransferObjects;

namespace LibraryBlazorWasmAdmin.Services
{
    public interface IAuthorManagerApiClient
    {
        Task<List<AuthorDto>> GetAllAuthor();
    }
}
