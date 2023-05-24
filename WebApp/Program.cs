using System.Text.Json;
using Microsoft.Extensions.Options;

using MickeyPi.Character;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CharacterSettings>(builder.Configuration.GetSection("CharacterSettings"));
builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<CharacterSettings>>().Value);
builder.Services.AddSingleton<CharacterHead>();

var app = builder.Build();
app.Logger.LogInformation(builder.Configuration.GetDebugView());

var characterSettings = app.Services.GetRequiredService<CharacterSettings>();
app.Logger.LogInformation($"\n\n{JsonSerializer.Serialize(characterSettings)}");

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
