using Currency.Exchange.Service.Contract;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICurrencyExchangeService, CurrencyExchangeService>();
builder.Services.AddSoapCore();
var application = builder.Build();
application.UseSoapEndpoint<ICurrencyExchangeService>("/Service.asmx", new SoapEncoderOptions());
application.MapGet("/", () => "Currency Exchange Service Running!");
application.Run();
