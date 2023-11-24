using Microsoft.EntityFrameworkCore;
using PCT.Infrastructure.Context;
using PCT.WebAPI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
var serviceScope = app.Services.CreateScope();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    await dataContext?.Database.MigrateAsync()!;
}

var seeder = serviceScope.ServiceProvider.GetService<ApplicationDbContextSeed>();
seeder?.SeedAsync();

app.UseSerilogRequestLogging();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();