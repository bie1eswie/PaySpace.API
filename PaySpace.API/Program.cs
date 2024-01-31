using Microsoft.EntityFrameworkCore;
using PaySpace.Data.Respository;
using PaySpace.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddCors(options =>
{
    string[] methods = { "GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS" };
    options.AddPolicy("AllowFrontend", builder => builder.WithOrigins("https://localhost:44315").AllowAnyHeader().WithMethods(methods));
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PaySpaceContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();
var logger = app.Services.GetService<ILogger<Program>>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowFrontend");
app.MapControllers();
app.ApplyMigration(logger);

app.Run();
