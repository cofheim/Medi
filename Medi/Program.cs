using Medi.Application.Services;
using Medi.DataAccess;
using Medi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MediDbContext>(options => 
{ 
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MediDbContext))); 
});

builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IMedicinesRepository, MedicinesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
