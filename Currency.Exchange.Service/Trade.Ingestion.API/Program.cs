using ServiceReference1;
using System.Text.Json;
using Trade.Ingestion.API.Models;
using Trade.Ingestion.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration);
builder.Services.AddScoped<DConnection>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    });
builder.Services.AddTransient<IDConnection, DConnection>();
builder.Services.AddTransient<ITradeDataDB, TradeDataDB>();
builder.Services.AddScoped<ICurrencyExchangeService>(provider =>
{
    return new CurrencyExchangeServiceClient(
        CurrencyExchangeServiceClient.EndpointConfiguration.BasicHttpBinding_ICurrencyExchangeService,
        "https://localhost:7251/Service.asmx" 
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
