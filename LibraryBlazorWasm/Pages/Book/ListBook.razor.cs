using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class ListBook
    {
        [Inject] IBookApiClient _bookApiClient { get; set; }
        private List<BookDto> Books;

        protected override async Task OnInitializedAsync()
        {
            Books = await _bookApiClient.GetAllBook();
        }
    }
}
