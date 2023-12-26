using EventBus.Messages.Events;
using MassTransit;
using Newtonsoft.Json;

namespace XCart.NotificationService2.Consumers
{
    public class OrderPlacedMessageConsumer : IConsumer<OrderPlacedEvent>
    {
        readonly ILogger<OrderPlacedMessageConsumer> _logger;

        public OrderPlacedMessageConsumer(ILogger<OrderPlacedMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderPlacedEvent> context)
        {
            _logger.LogInformation("NotificationService2 Order Placed Event Received Text: {Text}", JsonConvert.SerializeObject(context.Message));

            return Task.CompletedTask;
        }
    }
}
