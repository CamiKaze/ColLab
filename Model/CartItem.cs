using System;

namespace ColLab.Model
{
    public class CartItem
    {
        public int id { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public DateTime createdDate { get; }
        public int shoppingCartID { get; set; }
    }
}
