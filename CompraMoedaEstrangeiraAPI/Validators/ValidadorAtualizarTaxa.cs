using System;

namespace CompraMoedaEstrangeiraAPI.Validators
{
    public static class ValidadorAtualizarTaxa
    {
        public static void Valida(decimal valorTaxa)
        {
            if (valorTaxa < 0)
            {
                throw new ArgumentException("Valor da taxa não pode ser negativo");
            }
        }
    }
}
