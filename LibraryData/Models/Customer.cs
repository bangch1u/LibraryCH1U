using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } 
        public string Email { get; set; }

    }
}
