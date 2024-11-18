using LibraryBlazorWasmAdmin.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasmAdmin.Pages.BookManagers
{
    public partial class ListBook
    {
        [Inject] IBookManagerApiClient _bookApiClient { get; set; }
        public List<BookDto> Books;
        //[Parameter] public string id { get; set; }  
        protected override async Task OnInitializedAsync()
        {
            Books = await _bookApiClient.GetAllBook();
        }
        private async Task RemoveBook(Guid id)
        {
            await _bookApiClient.DeleteBook(id);
            Books = await _bookApiClient.GetAllBook();
        }
    }
}
