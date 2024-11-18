using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using LibraryBlazorWasmAdmin.Services;
using LibraryData.ViewModel;
using LibraryData.DataTransferObjects;
using LibraryData.Request;

namespace LibraryBlazorWasmAdmin.Pages.BookManagers
{
    public partial class BookCreate
    {
        [Inject] IAuthorManagerApiClient authorApiClient { get; set; }
        [Inject] IGenreManagerApiClient genreApiClient { get; set; }
        [Inject] IBookManagerApiClient bookApiClient { get; set; }

        private BookVM Book = new BookVM();
        private List<GenreDto> genresDtos { get; set; }
        private List<AuthorDto> authorDtos { get; set; }
        private int maxAllowedFiles = int.MaxValue;
        private long maxFileSize = long.MaxValue;
        private string fileName;
        private IBrowserFile imageFile;
        protected override async Task OnInitializedAsync()
        {
            authorDtos = await authorApiClient.GetAllAuthor();
            genresDtos = await genreApiClient.GetAllGenre();
        }
        private async Task HandleSubmit()
        {
            var bookRequest = new BookCreateRequest()
            {
                BookName = Book.BookName,
                BookPrices = Book.BookPrices,
                PublicationYear = Book.PublicationYear,
                GenreIds = selectedGenres,
                AuthorIds = selectedAuthors,
                ImgFile = imageFile

            };
            //bookApiClient.CreateBook(bookRequest);

            //Console.WriteLine(bookRequest.BookName);
            //Console.WriteLine(bookRequest.BookPrices);
            //Console.WriteLine(bookRequest.PublicationYear);
            //foreach (var item in bookRequest.AuthorIds)
            //{
            //    Console.WriteLine(item);
            //}
            await bookApiClient.CreateBook(bookRequest);
           
        }
    }
}
