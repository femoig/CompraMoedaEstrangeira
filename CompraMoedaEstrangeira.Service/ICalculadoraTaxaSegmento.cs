using CompraMoedaEstrangeira.Domain.Entities;

namespace CompraMoedaEstrangeira.Service
{
    public interface ICalculadoraTaxaSegmento
    {
        decimal ConsultaTaxa(Cliente cliente);
    }
}