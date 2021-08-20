using CompraMoedaEstrangeira.Domain.ResourceModel;

namespace CompraMoedaEstrangeira.Service
{
    public interface ICalculadoraService
    {
        ConsultaTaxaResponse ConsultaTaxa(int clienteID);
        CotacaoResponse CalculaCotacao(string moeda, decimal valor, int clienteID);
        ConsultaTaxaResponse ConsultaTaxaPorSegmento(string nomeSegmento);
    }
}
