using EventBus.Messages.Events;
using MassTransit;
using Newtonsoft.Json;

namespace XCart.NotificationService1.Consumers
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
            _logger.LogInformation("NotificationService1 Order Placed Text: {Text}", JsonConvert.SerializeObject(context.Message));

            return Task.CompletedTask;
        }
    }
}
