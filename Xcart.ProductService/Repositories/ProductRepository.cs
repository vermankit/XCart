namespace XCart.Product.Grpc.Repositories
{
    public class ProductRepository : IProductRepository
    {
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
