using LibraryBlazorWasmAdmin.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasmAdmin.Pages.BookManagers
{
    public partial class BookDetail
    {
        [Inject] IBookManagerApiClient BookApiClient { get; set; }
        public BookDto bookDto { get; set; }
        [Parameter]
        public Guid BookId { get; set; }
        protected override async Task OnInitializedAsync()
        {

            bookDto = await BookApiClient.GetBook(BookId);
        }
    }
}
