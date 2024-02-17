using RoyalLibrary.Infrastructure;
using RoyalLibrary.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await _context.Database.MigrateAsync();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
