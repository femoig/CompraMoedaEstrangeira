using CompraMoedaEstrangeira.Domain.Entities;

namespace CompraMoedaEstrangeira.Data
{
    public interface IClienteRepository
    {
        public Cliente BuscaCliente(int clienteID);
    }
}
