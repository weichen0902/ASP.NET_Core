using Microsoft.EntityFrameworkCore;
using ASP.NET_Core.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DataContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

var defaultConnectionString = builder.Configuration.GetConnectionString("DataConnection");
builder.Services.AddDbContext<DataContext>(options =>
options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString)));

var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        using (var dataDbContext = scope.ServiceProvider.GetService<DataContext>())
        {
            if (dataDbContext != null)
                dataDbContext.Database.Migrate();

        }
    }
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
    throw;
}

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
