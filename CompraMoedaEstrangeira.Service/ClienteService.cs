using CompraMoedaEstrangeira.Data;
using CompraMoedaEstrangeira.Domain.Entities;
using System;

namespace CompraMoedaEstrangeira.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente BuscaCliente(int clienteID)
        {
            return _clienteRepository.BuscaCliente(clienteID);
        }
    }
}
