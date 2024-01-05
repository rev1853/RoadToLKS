using SmkMovies.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// token 

string token = "fV8hZ4qN6xN7aX8rX0hT3mR4lO2sF8vF6oZ4gP4oM7wW8wJ4cN8bI0mV5mJ2kD7fX6dE4lC9xZ0zG3hP2aS9eU2iV2aY8lZ7aZ0s";

builder.Services.AddDbContext<EsemkaCinemaContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
