using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Diagnostics;

namespace GrpcServer.Interceptors
{

    // Cái Interceptor này giúp ta chặn các request/response
    // Cái này giống middleware trong ASP.NET Core
    public class LogginInterceptor : Interceptor
    {
        // Override hàm này để chặn các request kiểu Unary
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {

            // Phần 1: trước khi vào service
            Console.WriteLine($"[LOG] Đang nhận reuqest tới hàm: {context.Method}");

            // Bấm giờ xem hàm chạy mất bao lâu
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Phần 2: Cho phép chạy tiếp vào service
                // continuation chính là cái hàm service thực sự vd: GetProductInfo (IAsyncStreamReader<ProductRequest> requestStream, ServerCallContext context)
                var response = await continuation(request, context);

                stopwatch.Stop();
                Console.WriteLine($"[LOG] Xử lý xong {context.Method} trong {stopwatch.ElapsedMilliseconds}ms.");
                return response;
            }
            // ở đây để bắt các lỗi ngoại lệ nếu có vd: lỗi database, lỗi logic...
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($"[ERROR] Lỗi tại {context.Method}: {ex.Message}");
                throw; // ném lại lỗi để gRPC framework xử lý trả về cho client

            }

        }

    }
}
