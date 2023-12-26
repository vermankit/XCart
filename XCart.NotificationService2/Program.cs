using EventBus.Messages.Common;
using EventBus.Messages.Events;
using MassTransit;
using RabbitMQ.Client;
using XCart.NotificationService2.Consumers;

namespace XCart.NotificationService2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);


            builder.Services.AddMassTransit(config =>
            {
                config.AddConsumer<OrderPlacedMessageConsumer>();
                config.AddConsumer<UpdateOrderMessageConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.ReceiveEndpoint(EventBusConstants.OrderPlacedQueue2, c =>
                    {
                        c.ConfigureConsumeTopology = false;
                        c.ConfigureConsumer<OrderPlacedMessageConsumer>(ctx);
                        c.Bind<OrderPlacedEvent>(s =>
                        {
                            s.ExchangeType = ExchangeType.Fanout;
                        });
                        
                    });

                    cfg.ReceiveEndpoint(EventBusConstants.OrderUpdatedQueue, c =>
                    {
                        c.ConfigureConsumeTopology = false;
                        c.ConfigureConsumer<UpdateOrderMessageConsumer>(ctx);
                        c.Bind<OrderUpdatedEvent>(s =>
                        {
                            s.ExchangeType = ExchangeType.Topic;
                            s.RoutingKey = "order.updated";
                        });
                    });
                });
            });
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}