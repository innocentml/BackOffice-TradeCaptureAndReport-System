using ServiceReference1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICurrencyExchangeService>(provider =>
{
    return new CurrencyExchangeServiceClient(
        CurrencyExchangeServiceClient.EndpointConfiguration.BasicHttpBinding_ICurrencyExchangeService,
        "https://localhost:7251/Service.asmx" // Your SOAP Service URL
    );
});
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
