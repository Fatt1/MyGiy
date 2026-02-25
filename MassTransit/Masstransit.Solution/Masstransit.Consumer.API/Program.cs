
using Masstransit.Introduce.Dependency_Injection.Extensions;

namespace Masstransit.Consumer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Add RabbitMQ
            builder.Services.AddConfigureMasstransitRabbitMQ(builder.Configuration);

            // Add Meditor
            builder.Services.AddMeditor();

            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
