using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
