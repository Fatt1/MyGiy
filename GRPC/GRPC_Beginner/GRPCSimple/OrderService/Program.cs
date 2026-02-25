using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

namespace OrderService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // Tạo channel kết nối đến gRPC server
            using var channel = GrpcChannel.ForAddress("https://localhost:7115");

            // Tạo client từ channel
            var client = new ProductGrpc.ProductGrpcClient(channel);
            var deadline = DateTime.UtcNow.AddSeconds(2);

            try
            {
                Console.WriteLine("Đang gọi sang Product Service...");

                // Gọi hàm như gọi hàm nội bộ
                // Truyền thên deadline vào để giới hạn thời gian chờ
                // Thêm deadline vào để giới hạn thời gian chờ
                var reply = await client.GetProductInfoAsync(new ProductRequest { ProductId = 10 }, deadline: deadline);

                Console.WriteLine("Kết quả nhận được");
                Console.WriteLine($"Tên: {reply.Name}");
                Console.WriteLine($"Giá: {reply.Price}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] LỖI: Hết giờ rồi! Product Service trả lời quá chậm.");
            }

            catch (RpcException ex)
            {
                Console.WriteLine($"Lỗi gọi gRPC: {ex.Status.StatusCode} - {ex.Status.Detail}");
            }



            //Console.WriteLine("----Demo server streaming------");
            //using (var call = client.GetAllProduct(new GetAllProductRequest()))
            //{
            //    await foreach (var item in call.ResponseStream.ReadAllAsync())
            //    {
            //        Console.WriteLine($"Sản phẩm: {item.Name} - Giá: {item.Price}");
            //    }
            //}


            //Console.WriteLine("\n--- Demo Client Streaming (Bulk Insert) ---");
            //using var call = client.BulkInsertProduct();

            //for (int i = 1; i <= 5; i++)
            //{
            //    await call.RequestStream.WriteAsync(new ProductRequest
            //    {
            //        ProductId = i
            //    });

            //    await Task.Delay(500); // Giả lập chờ giữa các lần gửi
            //}


            //// Báo cho server là đã gửi xong
            //Console.WriteLine("Đã gửi xong, chờ Server xác nhận...");
            //await call.RequestStream.CompleteAsync();

            //var response = await call.ResponseAsync;
            //Console.WriteLine(response.Message);
        }
    }
}
