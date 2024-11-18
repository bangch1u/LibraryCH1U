using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class BookGenre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public int AgeLimit { get; set; }
        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }
    }
}
