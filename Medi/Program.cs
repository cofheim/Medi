using Infrastructure;
using Medi.Application.Services;
using Medi.DataAccess;
using Medi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<MediDbContext>(options => 
{ 
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MediDbContext))); 
});

builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IMedicinesRepository, MedicinesRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
