using System;

namespace Service.Validators
{
    public static class ValidadorAtualizarTaxa
    {
        public static void Valida(decimal valorTaxa)
        {
            if (valorTaxa < 0)
            {
                throw new InvalidOperationException("Valor da taxa não pode ser negativo");
            }
        }
    }
}
