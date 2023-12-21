namespace XCart.OrderService.Entity
{
    public class OrderItem
    {
        // Properties
        public Product Product { get; set; }
        public int Quantity { get; set; }

        // Computed property
        public decimal Subtotal => Quantity * Product.Price;

        // Constructor
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
