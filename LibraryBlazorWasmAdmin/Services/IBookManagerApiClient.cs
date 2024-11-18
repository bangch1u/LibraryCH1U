using LibraryData.DataTransferObjects;
using LibraryData.Request;

namespace LibraryBlazorWasmAdmin.Services
{
    public interface IBookManagerApiClient
    {
        Task<List<BookDto>> GetAllBook();
        Task<BookDto> GetBook(Guid id);
        Task CreateBook(BookCreateRequest bookCreateRequest);
        Task DeleteBook(Guid id);
    }
}
