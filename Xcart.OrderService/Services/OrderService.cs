using Grpc.Core;
using XCart.Order.Grpc.Protos;


namespace XCart.Order.Grpc.Services
{
    public class OrderService : OrderProtoService.OrderProtoServiceBase
    {
        public async override Task<ReplyModel> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            return new ReplyModel()
            {
                Message = "test"
            };
        }

        public async override Task<ReplyModel> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {
            return new ReplyModel()
            {
                Message = "test"
            };
        }
    }
}
