namespace XCart.Product.Grpc.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Entities.Product> ProductList = new()
        {
            new Entities.Product { Id = 1, Name = "Product1", Price = 10.99, Color = "Red", Description = "Description for Product1", Quantity = 5 },
            new Entities.Product { Id = 2, Name = "Product2", Price = 12.99, Color = "Blue", Description = "Description for Product2", Quantity = 7 },
            new Entities.Product { Id = 3, Name = "Product3", Price = 15.99, Color = "Green", Description = "Description for Product3", Quantity = 3 },
            new Entities.Product { Id = 4, Name = "Product4", Price = 18.99, Color = "Yellow", Description = "Description for Product4", Quantity = 8 },
            new Entities.Product { Id = 5, Name = "Product5", Price = 22.99, Color = "Purple", Description = "Description for Product5", Quantity = 10 },
            new Entities.Product { Id = 6, Name = "Product6", Price = 27.99, Color = "Orange", Description = "Description for Product6", Quantity = 12 },
            new Entities.Product { Id = 7, Name = "Product7", Price = 31.99, Color = "Pink", Description = "Description for Product7", Quantity = 15 },
            new Entities.Product { Id = 8, Name = "Product8", Price = 36.99, Color = "Brown", Description = "Description for Product8", Quantity = 20 },
            new Entities.Product { Id = 9, Name = "Product9", Price = 40.99, Color = "Black", Description = "Description for Product9", Quantity = 4 },
            new Entities.Product { Id = 10, Name = "Product10", Price = 45.99, Color = "White", Description = "Description for Product10", Quantity = 6 },
            new Entities.Product { Id = 11, Name = "Product11", Price = 50.99, Color = "Gray", Description = "Description for Product11", Quantity = 9 },
            new Entities.Product { Id = 12, Name = "Product12", Price = 55.99, Color = "Cyan", Description = "Description for Product12", Quantity = 11 },
            new Entities.Product { Id = 13, Name = "Product13", Price = 60.99, Color = "Magenta", Description = "Description for Product13", Quantity = 14 },
            new Entities.Product { Id = 14, Name = "Product14", Price = 65.99, Color = "Lime", Description = "Description for Product14", Quantity = 18 },
            new Entities.Product { Id = 15, Name = "Product15", Price = 70.99, Color = "Teal", Description = "Description for Product15", Quantity = 22 },
            new Entities.Product { Id = 16, Name = "Product16", Price = 75.99, Color = "Olive", Description = "Description for Product16", Quantity = 25 },
            new Entities.Product { Id = 17, Name = "Product17", Price = 80.99, Color = "Silver", Description = "Description for Product17", Quantity = 30 },
            new Entities.Product { Id = 18, Name = "Product18", Price = 85.99, Color = "Gold", Description = "Description for Product18", Quantity = 35 },
            new Entities.Product { Id = 19, Name = "Product19", Price = 90.99, Color = "Bronze", Description = "Description for Product19", Quantity = 40 },
            new Entities.Product { Id = 20, Name = "Product20", Price = 95.99, Color = "Platinum", Description = "Description for Product20", Quantity = 45 }
        };

        public Task<List<Entities.Product>> GetProducts()
        {
            return Task.FromResult(ProductList);
        }

        public Task PlaceOrder(List<int> productIds, string customerId)
        {
            return Task.CompletedTask;
        }

        public Task UpdateOrder(List<int> productIds, string orderId, string customerId)
        {
            return Task.CompletedTask;
        }
    }
}
