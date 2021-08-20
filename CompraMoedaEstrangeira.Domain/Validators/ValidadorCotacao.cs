using System;

namespace CompraMoedaEstrangeira.Domain.Validators
{
    public static class ValidadorCotacao
    {
        public static void Valida(string moeda, decimal valorDesejado, int clienteID)
        {
            if (string.IsNullOrEmpty(moeda))
                throw new ArgumentException("Moeda obrigatória. Exemplo de formato: USD");

            if (valorDesejado <= 0)
                throw new ArgumentException("Valor precisa ser positivo");

            if (clienteID == 0)
                throw new ArgumentException("ClienteID obrigatório.");
        }
    }
}
