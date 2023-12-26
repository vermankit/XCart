using EventBus.Messages.Events;
using MassTransit;
using Newtonsoft.Json;

namespace XCart.NotificationService2.Consumers
{
    public class UpdateOrderMessageConsumer : IConsumer<OrderUpdatedEvent>
    {
        readonly ILogger<UpdateOrderMessageConsumer> _logger;

        public UpdateOrderMessageConsumer(ILogger<UpdateOrderMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderUpdatedEvent> context)
        {
            _logger.LogInformation("NotificationService2 Order Update Event Received Text: {Text}", JsonConvert.SerializeObject(context.Message));

            return Task.CompletedTask;
        }
    }
}
