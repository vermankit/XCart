using Google.Protobuf.Collections;

namespace XCart.Product.Grpc.Repositories
{
    public interface IProductRepository
    {
        Task PlaceOrder(List<int> productIds, string customerId);
        Task UpdateOrder(List<int> productIds, string orderId, string customerId);
    }
}
