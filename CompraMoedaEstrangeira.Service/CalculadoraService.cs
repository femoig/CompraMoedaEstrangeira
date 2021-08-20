using CompraMoedaEstrangeira.Domain.ResourceModel;
using CompraMoedaEstrangeira.Domain.Validators;
using ExchangeRates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Service
{
    public class CalculadoraService : ICalculadoraService
    {
        private const string MoedaLocal = "BRL";
        private readonly IClienteService _clienteService;
        private readonly ISegmentoClienteService _segmentoClienteService;
        private readonly IExchangeRate _exchangeRate;
        private readonly ICalculadoraTaxaSegmento _calculadoraTaxaSegmento;

        public CalculadoraService(
            IClienteService clienteService, 
            ISegmentoClienteService segmentoClienteService,
            IExchangeRate exchangeRate,
            ICalculadoraTaxaSegmento calculadoraTaxaSegmento)
        {
            _clienteService = clienteService;
            _segmentoClienteService = segmentoClienteService;
            _exchangeRate = exchangeRate;
            _calculadoraTaxaSegmento = calculadoraTaxaSegmento;
        }

        public CotacaoResponse CalculaCotacao(string moeda, decimal valorDesejado, int clienteID)
        {
            try
            {
                ValidadorCotacao.Valida(moeda, valorDesejado, clienteID);

                var cliente = _clienteService.BuscaCliente(clienteID);

                decimal valorTaxaSegmento = _calculadoraTaxaSegmento.ConsultaTaxa(cliente);
                decimal taxaDeConversao = ConsultaTaxaConversao(moeda);
                decimal valorCotacao = CalculaCotacao(valorDesejado, valorTaxaSegmento, taxaDeConversao);

                var cotacaoResponse = ParseCotacao(valorCotacao, cliente, moeda, valorDesejado, clienteID, valorTaxaSegmento, taxaDeConversao);

                return cotacaoResponse;
            }
            catch (Exception ex)
            {
                return new CotacaoResponse { Erro = ex.Message };
            }
        }

        private static decimal CalculaCotacao(decimal valorDesejado, decimal valorTaxaSegmento, decimal taxaDeConversao)
        {
            return (valorDesejado * taxaDeConversao) * (1 + valorTaxaSegmento);
        }
        

        private CotacaoResponse ParseCotacao(decimal valorCotacao, Domain.Entities.Cliente cliente, string moeda, decimal valorDesejado, int clienteID, decimal valorTaxaSegmento, decimal valorCambio)
        {
            return new CotacaoResponse { 
                ValorCotacao = valorCotacao, 
                NomeSegmento = cliente.NomeSegmento,
                MoedaDesejada = moeda.ToUpper(),
                ValorDesejado = valorDesejado,
                ValorTaxaSegmento = valorTaxaSegmento,
                ValorCambio = valorCambio,
                ClienteID = clienteID
            };
        }

        public ConsultaTaxaResponse ConsultaTaxa(int clienteID)
        {
            var cliente = _clienteService.BuscaCliente(clienteID);
            var valorTaxa = _segmentoClienteService.ConsultaTaxaPorSegmento(cliente.NomeSegmento);

            ConsultaTaxaResponse response = ParseConsultaTaxa(valorTaxa, cliente.NomeSegmento);

            return response;
        }

        private ConsultaTaxaResponse ParseConsultaTaxa(decimal valorTaxa, string nomeSegmento)
        {
            return new ConsultaTaxaResponse { NomeSegmento = nomeSegmento, ValorTaxa = valorTaxa };
        }

        public ConsultaTaxaResponse ConsultaTaxaPorSegmento(string nomeSegmento)
        {
            var valorTaxa = _segmentoClienteService.ConsultaTaxaPorSegmento(nomeSegmento); 
            ConsultaTaxaResponse response = ParseConsultaTaxa(valorTaxa, nomeSegmento);

            return response;
        }

        private decimal ConsultaTaxaConversao(string moedaDesejada)
        {
            return _exchangeRate.ConsultaTaxaConversao(MoedaLocal, moedaDesejada);
        }
    }
}
