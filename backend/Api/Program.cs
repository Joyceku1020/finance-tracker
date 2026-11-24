using FinanceTracker.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment()) 
{
    throw new InvalidOperationException( "The API cannot run outside Development until authentication is configured" );
}

var connectionString = builder.Configuration.GetConnectionString("FinanceTracker") 
    ?? throw new InvalidOperationException(
        "The FinanceTracker connection string is missing.");

builder.Services.AddDbContext<FinanceTrackerDbContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
