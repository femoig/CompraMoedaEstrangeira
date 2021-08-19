using CompraMoedaEstrangeira.Domain.Entities;
using System;

namespace CompraMoedaEstrangeira.Data
{
    public interface IClienteRepository
    {
        public Cliente BuscaCliente(int clienteID);
    }
}
