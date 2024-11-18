using LibraryData.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class Order
    {
        public Guid Id { get; set; }    
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Purchasetime { get; set; }
        public OrderStatus Status { get; set; }

    }

}
