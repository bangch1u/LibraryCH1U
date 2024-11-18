using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Data;
using LibraryData.Request;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class BookCreate
    {
        [Inject] IAuthorApiClient authorApiClient {  get; set; }
        [Inject] IGenreApiClient genreApiClient {  get; set; }
        [Inject] IBookApiClient bookApiClient {  get; set; }
       
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
