using HomeTask;
using HomeTask.Data.Context;
using HomeTask.Dtos;
using HomeTask.Mapping;
using HomeTask.Repository.Implementation;
using HomeTask.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Serilog;
         


try
{
    Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
       System.IO.Path.Combine("C:\\Users\\Admin\\Desktop\\logFiles", "Application", "diagnostics.txt"),
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
    .WriteTo.Console()
    .CreateLogger();

    Log.Information("Starting web application");


    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddHttpLogging(c =>
    {
        c.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseStatusCode
        | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseHeaders;
        //| Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseBody; 
        // ------------------------------------------Here we show our result directly on console--------------------------
    });

    builder.Host.UseSerilog(); // <-- Add this line


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
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
