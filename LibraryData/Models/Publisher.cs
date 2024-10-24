using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Publisher
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }
    }
}
