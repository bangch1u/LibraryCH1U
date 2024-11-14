using LibraryData.DataTransferObjects;

namespace LibraryBlazorWasm.Services
{
    public interface IBookApiClient
    {
        Task<List<BookDto>> GetAllBook();
        Task<BookDto> GetBook(Guid id);
    }
}
