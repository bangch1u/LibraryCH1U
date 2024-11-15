using LibraryData.DataTransferObjects;
using LibraryData.Request;
using LibraryData.ViewModel;

namespace LibraryBlazorWasm.Services
{
    public interface IBookApiClient
    {
        Task<List<BookDto>> GetAllBook();
        Task<BookDto> GetBook(Guid id);
        Task CreateBook(BookCreateRequest bookCreateRequest);
    }
}
