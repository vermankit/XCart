namespace XCart.Product.Grpc.Entities
{
    public class Product
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        
    }
}
