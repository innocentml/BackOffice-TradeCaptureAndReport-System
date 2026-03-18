using Currency.Exchange.Service.Contract;
using Currency.Exchange.Service.Models;

namespace Currency.Exchange.Service.Tests.Contract
{
    public class CurrencyExchangeServiceTest
    {
        [Test]
        public void GetRate_GivenNullRateRequest_ShouldReturnNull() 
        {
            //Arrange
            var currencyExchangeService = new CurrencyExchangeService();

            //Act
            var response = currencyExchangeService.GetRate(null!);

            //Assert
            Assert.IsNull(response);
        }

        [Test]
        public void GetRate_GivenEmptyFromCurrencyOrToCurrencyRateRequest_ShouldReturnNull()
        {
            //Arrange
            var currencyExchangeService = new CurrencyExchangeService();
            var rateRequest = new RateRequest
            {
                FromCurrency = " ",
                ToCurrency = " ",
            };

            //Act
            var response = currencyExchangeService.GetRate(rateRequest);

            //Assert
            Assert.IsNull(response);
        }

        [Test]
        public void GetRate_GivenValidRateRequest_ShouldReturnValidResponse()
        {
            //Arrange
            var currencyExchangeService = new CurrencyExchangeService();
            var rateRequest = new RateRequest
            {
                FromCurrency = "EUR",
                ToCurrency = "USD",
            };

            //Act
            var response = currencyExchangeService.GetRate(rateRequest);

            //Assert
            Assert.That(response!.Value, Is.EqualTo(1.02));
        }
    }
}
