using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasm.Components.ListBookComponents
{
    public partial class BookTheBest
    {
        [Inject] private IBookApiClient _bookApiClient { get; set; }
        public List<BookDto> Books;

        protected override async Task OnInitializedAsync()
        {
            Books = await _bookApiClient.GetAllBook();
        }
    }
}
