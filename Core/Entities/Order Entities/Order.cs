using Core.Entities.Core_Entities;

namespace Core.Entities.Order_Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>(); // Related cart items
    }
}

