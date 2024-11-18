
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class Book 
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookPrices { get; set; }
        public DateTime PublicationYear { get; set; }
        public string ImgFile { get; set; }
        public int Quantity { get; set; }
        public ICollection<Author>? Authors { get; set; }
        public ICollection<BookGenre>? Genres { get; set; }
       
       
    }
}
