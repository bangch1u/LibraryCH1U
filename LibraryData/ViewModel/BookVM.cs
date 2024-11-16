using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.ViewModel
{
    public class BookVM
    {
        public string BookName { get; set; }
        public decimal BookPrices { get; set; }
        public DateTime PublicationYear { get; set; }
        public string? ImgFile { get; set; }
    }
}
