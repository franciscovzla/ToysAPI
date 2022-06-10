global using Microsoft.EntityFrameworkCore;
global using Data;
using Services.Contracts;
using Services.Services;
var builder = WebApplication.CreateBuilder(args);
//TODO: Naming convension of projects its usually ProjectName.Layer ex: ToysAPI.Data, ToysAPI.Models.
//This usage of explicit project.projectname its because you can have multiple APIs in the solution with multiple Data,Service,Test Layers.


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options=> { options.MigrationsAssembly("Data"); });
});

//builder.Services.AddScoped<DbContext, DataContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//TODO: Move this to an extension method in the Services Project
//buider.Services(ToysAPI.Services.AddServices())
builder.Services.AddScoped<IToyService, ToyService>();
var app = builder.Build();

//TODO: Suset Video, Add logic to run migration automatically

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
