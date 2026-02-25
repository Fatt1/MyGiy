
using Grpc.Core;
namespace GrpcServer.Services
{
    public class ProductService : ProductGrpc.ProductGrpcBase
    {
        // Stimulate a database
        private readonly static Dictionary<int, (string Name, double Price)> _fakeDb = new()
        {
            {1, ("Laptop", 999.99)},
            {2, ("Smartphone", 499.49)},
            {3, ("Tablet", 299.29) }
        };

        public override async Task<GetProductResponse> GetProductInfo(ProductRequest request, ServerCallContext context)
        {
            try
            {
                await Task.Delay(1000, context.CancellationToken); // Simulate a long process
                if (_fakeDb.TryGetValue(request.ProductId, out var item))
                {

                    return new GetProductResponse
                    {
                        Id = request.ProductId,
                        IsAvailable = true,
                        Name = item.Name,
                        Price = item.Price
                    };
                }

                throw new RpcException(new Status(StatusCode.NotFound, $"Product id = {request.ProductId} not found"));
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine($"Request lấy sản phẩm {request.ProductId} đã bị hủy do Client không chờ nữa.");
                throw; // Ném lỗi ra để gRPC framework xử lý dọn dẹp
            }

        }


        // Server-Streaming RPC
        // Có nghĩa là client và server gửi dữ liệu cho nhau liên tục
        // Ở đây hàm GetAllProduct sẽ gửi liên tục các sản phẩm cho client cho đến hết
        // Khác với Unary nếu mà lấy 1000 sản phẩm thì phải đợi rất lâu
        // cái này là server gửi từng sản phẩm một cho client
        public override async Task GetAllProduct(GetAllProductRequest request, IServerStreamWriter<GetProductResponse> responseStream, ServerCallContext context)
        {

            // Giả lập danh sách 5 sản phẩm
            var products = new List<GetProductResponse>
            {
                new() { Id = 1, Name = "Laptop Gaming", Price = 1500 },
                new() { Id = 2, Name = "Chuột", Price = 20 },
                new() { Id = 3, Name = "Bàn phím cơ", Price = 100 },
                new() { Id = 4, Name = "Màn hình 4K", Price = 400 },
                new() { Id = 5, Name = "Tai nghe", Price = 50 },
            };
            foreach (var product in products)
            {
                // Gia lap thoi gian doc tren db 
                await Task.Delay(1000, context.CancellationToken);

                // Kiểm tra xem client có ngắt kết nối đột ngột không. Nếu ngắt thì sẽ dừng luôn
                if (context.CancellationToken.IsCancellationRequested) break;

                await responseStream.WriteAsync(product);
                Console.WriteLine($"-> Đã gửi: {product.Name}");
            }
            Console.WriteLine("Đã gửi xong dữ liệu");
        }


        // Client-Streaming RPC
        // Client sẽ gửi một luồng dữ liệu (stream) lên server
        public override async Task<BulkInsertResponse> BulkInsertProduct(IAsyncStreamReader<ProductRequest> requestStream, ServerCallContext context)
        {
            int count = 0;
            await foreach (var request in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"Server nhận yêu cầu thêm: ID {request.ProductId}");
                count++;
                // Thực tế: Lưu vào DB ở đây
            }

            return new BulkInsertResponse
            {
                Count = count,
                Message = $"Đã thêm thành công {count} sản phẩm."
            };
        }
    }

}
