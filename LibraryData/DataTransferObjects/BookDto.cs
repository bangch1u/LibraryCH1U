using LibraryData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.DataTransferObjects
{
    public class BookDto
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookPrices { get; set; }
        public DateTime PublicationYear { get; set; }
        public string ImgFile { get; set; }
        public  List<string> AuthorNames { get; set; }  
        public List<string> Genres { get; set; }    

    }
}
