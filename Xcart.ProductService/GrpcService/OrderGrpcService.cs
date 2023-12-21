using XCart.Order.Grpc.Protos;

namespace XCart.Product.Grpc.GrpcService
{
    public class OrderGrpcService
    {
        private readonly OrderProtoService.OrderProtoServiceClient _protoServiceClient;

        public OrderGrpcService(OrderProtoService.OrderProtoServiceClient protoServiceClient)
        {
            _protoServiceClient = protoServiceClient;
        }

        public async Task<bool> PlaceOrder(string customerId,List<int> products)
        {
            var result = await _protoServiceClient.PlaceOrderAsync(new PlaceOrderRequest()
            {
                CustomerId = customerId,
                ProductIds = { products }
            });
            return result.IsSuccess;
        }

        public async Task<bool> UpdateOrder(string customerId, List<int> products,string orderId)
        {
            var result = await _protoServiceClient.UpdateOrderAsync(new UpdateOrderRequest()
            {
                CustomerId = customerId,
                ProductIds = { products },
                OrderId = orderId
            });
            return result.IsSuccess;
        }
    }
}
