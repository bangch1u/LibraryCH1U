using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class BookDetails
    {
        [Inject] IBookApiClient BookApiClient { get; set; }
        private  BookDto bookDto { get; set; }
        [Parameter]public Guid idBook { get; set; }
        protected override async Task OnInitializedAsync()
        {
            bookDto = await BookApiClient.GetBook(idBook);
        }
    }
}
