using JWTAuthentication.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EsemkaCorporationContext>();

builder.Services.AddAuthorization();

// jwt settings
builder.Services
    .AddAuthentication()
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Key"]!)),
        };
    });


// settingan swagger untuk menambahakan button authorize
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.AddSecurityDefinition("fasfas", new OpenApiSecurityScheme { 
        In = ParameterLocation.Header,
        Description = "Tolong isi jwtnya",
        Name = "Authentication",
        // supaya tidak perlu menuliskan Bearer
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "fasfas"
                }
            },
            Array.Empty<string>()
        },
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
