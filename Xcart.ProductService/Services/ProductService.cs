using Grpc.Core;
using XCart.Product.Grpc.GrpcService;
using XCart.Product.Grpc.Protos;
using XCart.Product.Grpc.Repositories;

namespace XCart.Product.Grpc.Services
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {

        private readonly OrderGrpcService _orderGrpcService;
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository, OrderGrpcService orderGrpcService)
        {
            _repository = repository;
            _orderGrpcService = orderGrpcService;
        }


        public override async Task<Products> GetProducts(Params request, ServerCallContext context)
        {
            var products = await _repository.GetProducts();
            var productBufList = products.Select(product => new Protos.Product()
            {
                ProductId = product.Id,
                Color = product.Color,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            }).ToList();

            var productResponse = new Products()
            {
                Products_ = { productBufList }
            };
            return await Task.FromResult(productResponse);
        }

        public override async Task<ReplyModel> CreateOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            var productIds = request.Products.Select(product => product.ProductId).ToList();
            await _repository.PlaceOrder(productIds, request.CustomerId);
            var result = await _orderGrpcService.PlaceOrder(request.CustomerId, productIds);


            return new ReplyModel
            {
                Message = result ? "Order Placed" : "Order Failed"
            };
        }

        public override async Task<ReplyModel> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {
            var productIds = request.Products.Select(product => product.ProductId).ToList();
            await _repository.UpdateOrder(productIds, request.OrderId, request.CustomerId);
            var result = await _orderGrpcService.UpdateOrder(request.CustomerId, productIds, request.OrderId);
            return new ReplyModel
            {
                Message = result ? "Order Placed" : "Order Failed"
            };
        }
    }
}
