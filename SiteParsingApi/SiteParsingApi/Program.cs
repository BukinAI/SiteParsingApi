using business;
using business.abstractions;
using SiteParsingApi.Infrastructure;
using business.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Add(new ServiceDescriptor(typeof(ITextParsingService), typeof(TextParsingService), ServiceLifetime.Singleton));
builder.Services.Add(new ServiceDescriptor(typeof(ITextGrouper), typeof(TextGrouper), ServiceLifetime.Singleton));
builder.Services.Add(new ServiceDescriptor(typeof(ITextParser), typeof(TextParser), ServiceLifetime.Singleton));
builder.Logging.AddFileLogging(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
