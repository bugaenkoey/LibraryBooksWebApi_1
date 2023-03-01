using LibraryBooksWebApi.Models;
using Microsoft.Data.SqlClient;

internal class Program
{

    private static void Main(string[] args)
    {
        new ApplicationContext();
        //CreateHostBuilder(args).Build().Run();


        var builder = WebApplication.CreateBuilder(args);

        //var conStrBuilder = new SqlConnectionStringBuilder(
        // builder.Configuration.GetConnectionString("LibraryBooks"));
        //conStrBuilder.Password = builder.Configuration["DbPassword"];
        //var connection = conStrBuilder.ConnectionString;

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


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