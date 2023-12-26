using EventBus.Messages.Common;
using EventBus.Messages.Events;
using MassTransit;
using RabbitMQ.Client;
using XCart.NotificationService1.Consumers;

namespace XCart.NotificationService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);


            builder.Services.AddMassTransit(config =>
            {
                config.AddConsumer<OrderPlacedMessageConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.ReceiveEndpoint(EventBusConstants.OrderPlacedQueue1, c =>
                    {
                        c.ConfigureConsumeTopology = false;
                        c.ConfigureConsumer<OrderPlacedMessageConsumer>(ctx);
                        c.Bind<OrderPlacedEvent>(s =>
                        {
                            s.ExchangeType = ExchangeType.Fanout;
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