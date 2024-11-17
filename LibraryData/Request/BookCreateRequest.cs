using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Request
{
    public class BookCreateRequest
    {
        public string BookName { get; set; }
        public decimal BookPrices { get; set; }
        public DateTime PublicationYear { get; set; }
        public IBrowserFile ImgFile { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public List<Guid> GenreIds { get; set; }

    }
}
