
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Logging.Core.IStore, Logging.Core.FileLogger>();
builder.Services.AddSingleton(typeof(Logging.Core.ILogger<>), typeof(Logging.Core.Logger<>));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
