using EventBus.Messages.Events;
using Grpc.Core;
using MassTransit;
using XCart.Order.Grpc.Protos;


namespace XCart.Order.Grpc.Services
{
    public class OrderService : OrderProtoService.OrderProtoServiceBase
    {
        private IPublishEndpoint _publishEndpoint;

        public OrderService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<ReplyModel> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            // Create Place order Event
            var eventMessage = new OrderPlacedEvent()
            {
                CustomerId = request.CustomerId,
                ProductIds = request.ProductIds.Select(product => product).ToList(),
            };

            // Send Event to rabbit MQ
            await _publishEndpoint.Publish(eventMessage);

            return new ReplyModel()
            {
                Message = "Order Placed",
                IsSuccess = true
            };
        }

        public override async Task<ReplyModel> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {

            // Create Place order Event
            var eventMessage = new OrderUpdatedEvent()
            {
                OrderId = request.OrderId,
                CustomerId = request.CustomerId,
                ProductIds = request.ProductIds.Select(product => product).ToList(),
            };

            // Send Event to rabbit MQ
            await _publishEndpoint.Publish(eventMessage,ctx => ctx.SetRoutingKey("order.updated"));
            return new ReplyModel()
            {
                Message = "Order Updated",
                IsSuccess = true
            };
        }
    }
}
