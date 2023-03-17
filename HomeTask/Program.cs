using HomeTask;
using HomeTask.Data.Context;
using HomeTask.Mapping;
using HomeTask.Repository.Implementation;
using HomeTask.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AppMapping));


builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opts =>
                                      opts.UseSqlServer(builder.Configuration.GetConnectionString("defaultServer")));

builder.Services.AddScoped<IEmployeeRepository, EmployessRepository>();

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