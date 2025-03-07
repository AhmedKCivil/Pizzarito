using Core.Entities.Core_Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Order_Entities
{
    public class AllOrders
    {
        public int Id { get; set; } 
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }  
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double TotalPrice { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}

