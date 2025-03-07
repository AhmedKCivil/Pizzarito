using Core.Entities.Order_Entities;

namespace Core.Entities.Core_Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }  // Primary key for the cart item
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        //public double TotalPrice => Quantity * PizzaPrice;

        // Foreign Key to OrderListModel
        public int AllOrdersId { get; set; }

        // Navigation property to link to the order
        public AllOrders Order { get; set; }

        //Custom Pizza Attributes
        public bool StuffedCrust { get; set; }
        public bool ThinCrispy { get; set; }
        public bool Chicken { get; set; }
        public bool Pepperoni { get; set; }

    }
}


