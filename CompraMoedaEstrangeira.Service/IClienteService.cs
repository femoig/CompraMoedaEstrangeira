using CompraMoedaEstrangeira.Domain.Entities;

namespace CompraMoedaEstrangeira.Service
{
    public interface IClienteService
    {
        public Cliente BuscaCliente(int clienteID);
    }
}