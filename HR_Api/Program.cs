
using InfraStractur.Data;
using InfraStractur.RigestarPrograming;

namespace HR_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<HR_Connect>();
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
                // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
                builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            Rigestar.AddRepositories(builder.Services);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
