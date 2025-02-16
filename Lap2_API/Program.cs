
using Lap2_API.MapperConfig;
using Lap2_API.Models;
using Lap2_API.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Lap2_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ITIContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("iticon")));
            builder.Services.AddAutoMapper(typeof(AutoMapp));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    // builder.WithOrigins("https://localhost:7085"); //لو عاوزه اخليه يتعامل مع localhost محدد 
                    //builder.WithMethods("Post","get"); //local host يعمل حجات معينه بس 
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(txt);
            app.MapControllers();

            app.Run();
        }
    }
}
