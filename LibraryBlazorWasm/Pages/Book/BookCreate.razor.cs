using LibraryBlazorWasm.Services;
using LibraryData.DataTransferObjects;
using LibraryData.Models;
using LibraryData.Request;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace LibraryBlazorWasm.Pages.Book
{
    public partial class BookCreate
    {
        [Inject] IAuthorApiClient authorApiClient {  get; set; }
        [Inject] IGenreApiClient genreApiClient {  get; set; }
        [Inject] IBookApiClient bookApiClient {  get; set; }
       
        public IFormFile imageFile;
        private BookVM Book = new BookVM();
        private List<GenreDto> genresDtos { get; set; }
        private List<AuthorDto> authorDtos { get; set; }
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
                ImgFile = Book.ImgFile

            };
            //bookApiClient.CreateBook(bookRequest);
          
            Console.WriteLine(bookRequest.BookName);
            Console.WriteLine(bookRequest.BookPrices);
            Console.WriteLine(bookRequest.PublicationYear);
            foreach (var item in bookRequest.AuthorIds)
            {
                Console.WriteLine(item);
            }
            bookApiClient.CreateBook(bookRequest);
        }
    }
}
