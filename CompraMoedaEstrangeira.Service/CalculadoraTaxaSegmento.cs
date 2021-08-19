using CompraMoedaEstrangeira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Service
{
    public class CalculadoraTaxaSegmento : ICalculadoraTaxaSegmento
    {
        private readonly ISegmentoClienteService _segmentoClienteService;

        public CalculadoraTaxaSegmento(ISegmentoClienteService segmentoClienteService)
        {
            _segmentoClienteService = segmentoClienteService;
        }

        public decimal ConsultaTaxa(Cliente cliente)
        {
            return _segmentoClienteService.ConsultaTaxaPorSegmento(cliente.NomeSegmento);
        }
    }
}
