using CompraMoedaEstrangeira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Data
{

    public class ClienteRepository : IClienteRepository
    {
        Dictionary<int, Cliente> keys;
        public ClienteRepository()
        {
            AdicionandoClientesFake();
        }

        private void AdicionandoClientesFake()
        {
            keys = new Dictionary<int, Cliente>();
            keys.Add(0, new ClienteVarejo());
            keys.Add(1, new ClientePersonnalite());
            keys.Add(2, new ClientePrivate());
        }

        public Cliente BuscaCliente(int clienteID)
        {
            Cliente cliente = CriaClienteAleatorio();

            return cliente;
        }

        private Cliente CriaClienteAleatorio()
        {
            Cliente cliente = default(Cliente);
            Random random = new Random();
            int randomNumber = random.Next(0, 2);

            keys.TryGetValue(randomNumber, out cliente);
            return cliente;
        }
    }
}
