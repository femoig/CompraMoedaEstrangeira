using System;

namespace ExchangeRates
{
    public class FakeExchangeRate : IExchangeRate
    {
        Random random = new Random();
        public decimal ConsultaTaxaConversao(string moedaLocal, string moedaDesejada)
        {
            return Convert.ToDecimal(random.Next(2, 5));
        }
    }
}
