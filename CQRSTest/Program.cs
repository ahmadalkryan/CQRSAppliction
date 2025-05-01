using CQRSLib.Data;
using CQRSLib.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using AppContext = System.AppContext;
using CQRSLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppdbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("cqrs")));

builder.Services.AddScoped<IItemRepo,ItemRepo>(); 

builder.Services.AddMediatR(typeof(Mylib).Assembly);

   

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
