namespace XCart.OrderService.Entity
{
    public class Product
    {
        // Properties
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Constructor
        public Product(int productId, string color, string description, decimal price, int stockQuantity)
        {
            ProductId = productId;
            Color = color;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }

}
