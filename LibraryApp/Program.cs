using LibraryApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// AddDataBase
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});

// Add all Scoped AppServices
var appServices = typeof(Program).Assembly.GetTypes().Where(s => s.Name.EndsWith("Service") && s.IsInterface == false).ToList();
foreach (var appService in appServices)
    builder.Services.Add(new ServiceDescriptor(appService, appService, ServiceLifetime.Scoped));

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
