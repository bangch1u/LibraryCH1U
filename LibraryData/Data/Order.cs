using LibraryData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }    
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Purchasetime { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }

}
