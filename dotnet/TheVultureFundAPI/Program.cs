/*
* In ASP.NET Core, services such as the DB Context must be registered with the dependency injection (DI)
* container.
* The container provides the service to controllers.
*/

using Microsoft.EntityFrameworkCore;
using TheVultureFundAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = "server=localhost;user=drdev;password=Pas$word173#@!;database=TheVultureFundDB";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

builder.Services.AddDbContext<TheVultureFunAPIDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
        );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow CORS:
var MyAllowedOrigins = "_myCORS";

builder.Services.AddCors(options =>{
    options.AddPolicy(name: MyAllowedOrigins, 
    policy => 
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowedOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
