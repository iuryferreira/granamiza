using Granamiza.Api.Configs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration);


var app = builder.Build();
app.UseApi();

app.Run();
