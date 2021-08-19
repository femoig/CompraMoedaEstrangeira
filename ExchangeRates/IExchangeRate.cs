namespace ExchangeRates
{
    public interface IExchangeRate
    {
        decimal ConsultaTaxaConversao(string moedaOrigem, string moedaDesejada);
    }
}