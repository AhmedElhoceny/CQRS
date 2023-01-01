using Application.DependencyInjection;
using Persistence.DependenciesInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Tier Dependencies Injection 
builder.Services.LoadDependencies();

// Persistence Tier Dependencies Injection 
builder.Services.LoadPersistenceDependencies(configuration);


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
