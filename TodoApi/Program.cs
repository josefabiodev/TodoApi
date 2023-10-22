using Microsoft.EntityFrameworkCore;
using Refit;
using TodoApi.Data;
using TodoApi.Integration;
using TodoApi.Integration.Interfaces;
using TodoApi.Integration.Refit;
using TodoApi.Repositories;
using TodoApi.Repositories.Interfaces;

namespace TodoApi
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TodoDbContext>(
                    Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br/");
            });

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