using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Configuration;
using RabbitMQ.Client;

namespace XCart.Order.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();
            var configuration = builder.Configuration;
            //Mass Transit - RabbitMQ Configuration
            builder.Services.AddMassTransit(
                opt =>
                {
                    opt.UsingRabbitMq((context, config) =>
                    {
                        config.Host(configuration["EventBusSettings:HostAddress"]);
                        // Configure the Fanout exchange
                        config.Publish<OrderPlacedEvent>(x => x.ExchangeType = ExchangeType.Fanout);
                       
                        // Configure the Topic exchange
                        
                        config.Publish<OrderUpdatedEvent>(x =>
                        {
                            x.ExchangeType = ExchangeType.Topic;
                        });
                        

                    });
                });
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<Services.OrderService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }

        string GetRoutingKey(string routingKey)
        {
            return $"order.{routingKey}";
        }
    }
}