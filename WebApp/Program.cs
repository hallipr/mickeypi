using System.Text.Json;
using Microsoft.Extensions.Options;

using MickeyPi.Character;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

CharacterSettings settings = new();
builder.Configuration.GetRequiredSection("CharacterSettings").Bind(settings);

builder.Services.AddSingleton(settings);
builder.Services.AddSingleton<CharacterHead>();

var app = builder.Build();
app.Logger.LogInformation(builder.Configuration.GetDebugView());

var characterSettings = app.Services.GetRequiredService<CharacterSettings>();
var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
app.Logger.LogInformation($"\n\n{JsonSerializer.Serialize(settings, jsonOptions)}");
app.Logger.LogInformation($"\n\n{JsonSerializer.Serialize(app.Services.GetRequiredService<CharacterSettings>(), jsonOptions)}");

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
