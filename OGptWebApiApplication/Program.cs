using OGptWebApiApplication.Services;
using OpenAI.GPT3.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var apiKey = builder.Configuration["apiKey"];
builder.Services.AddOpenAIService(setting=>setting.ApiKey= apiKey);

builder.Services.AddSingleton<CompletionServices>();
builder.Services.AddSingleton<ImagesServices>();


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
