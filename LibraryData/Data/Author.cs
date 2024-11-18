using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Birth {  get; set; }
        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }    
    }
}
