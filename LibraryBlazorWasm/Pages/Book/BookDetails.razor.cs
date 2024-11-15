using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class BookDetails
    {
        [Inject] IBookApiClient BookApiClient { get; set; }
        public  BookDto bookDto { get; set; }
        [Parameter]
        public Guid BookId { get; set; }
        protected override async Task OnInitializedAsync()
        {
          
            bookDto = await BookApiClient.GetBook(BookId);
        }
    }
}
