using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Birth {  get; set; }
    }
}
