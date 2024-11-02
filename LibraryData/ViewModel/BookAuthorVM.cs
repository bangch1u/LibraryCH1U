using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.ViewModel
{
    public class BookAuthorVM
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
    }
}
