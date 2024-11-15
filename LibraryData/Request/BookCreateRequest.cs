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
        public string ImgFile { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public List<Guid> GenreIds { get; set; }

    }
}
