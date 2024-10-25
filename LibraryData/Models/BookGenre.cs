using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class BookGenre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public int AgeLimit { get; set; }
    }
}
