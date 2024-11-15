using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Components;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class BookCreate
    {
        [Inject] IAuthorApiClient authorApiClient {  get; set; }    
        private BookVM Book = new BookVM();
        private List<AuthorDto> authorDtos { get; set; }
        protected override async Task OnInitializedAsync()
        {
            authorDtos = await authorApiClient.GetAllAuthor();
        }
    }
}
