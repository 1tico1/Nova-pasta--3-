using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MyWebAPIProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurações do MongoDB
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDBSettings:ConnectionString")));

// Injeção do ItemService
builder.Services.AddScoped<ItemService>();

// Configurações padrão da WebAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurações de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
