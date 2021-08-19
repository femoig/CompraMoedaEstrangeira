using CompraMoedaEstrangeira.Domain.ResourceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Service
{
    public interface ICalculadoraService
    {
        ConsultaTaxaResponse ConsultaTaxa(int clienteID);
        CotacaoResponse CalculaCotacao(string moeda, decimal valor, int clienteID);
        ConsultaTaxaResponse ConsultaTaxaPorSegmento(string nomeSegmento);
    }
}
