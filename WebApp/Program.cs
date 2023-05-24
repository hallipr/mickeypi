using System.Text.Json;

using MickeyPi.Character;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var characterSettings = new CharacterSettings();
builder.Configuration.Bind(nameof(CharacterSettings), characterSettings);
builder.Services.AddSingleton(characterSettings);
builder.Services.AddSingleton<CharacterHead>();

var app = builder.Build();

app.Logger.LogInformation(builder.Configuration.GetDebugView());
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
