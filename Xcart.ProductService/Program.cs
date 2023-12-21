using XCart.Order.Grpc.Protos;
using XCart.Product.Grpc.GrpcService;
using XCart.Product.Grpc.Infrastructure.Configuration;
using XCart.Product.Grpc.Repositories;
using XCart.Product.Grpc.Services;

namespace XCart.Product.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc().AddJsonTranscoding();
            // Add services to the container.
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            // Configure the app settings
            var configuration = builder.Configuration;
            var grpcSettings = configuration.GetSection("GrpcSettings").Get<GrpcSettings>();

            builder.Services.AddGrpcClient<OrderProtoService.OrderProtoServiceClient>(o =>
            {
                o.Address = new Uri(grpcSettings.OrderUrl);
            });

            builder.Services.AddTransient<OrderGrpcService>();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ProductService>();
                app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            });

            app.Run();
        }
    }
}