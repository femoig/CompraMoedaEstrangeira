using System;

namespace CompraMoedaEstrangeiraAPI.Validators
{
    public static class ValidadorCalculadoraMoedaEstrangeira
    {
        public static void CotacaoMoedaValidate(string moeda, decimal valor, int clienteID)
        {
            if (string.IsNullOrEmpty(moeda) || valor == 0 || clienteID == 0)
            {
                throw new ArgumentException("Os campos [moeda,valor,clienteID] são obrigatórios");
            }

            if (!string.IsNullOrEmpty(moeda) && moeda.Length != 3)
            {
                throw new ArgumentException("Moeda no formato inválido. A moeda precisa ter 3 dígitos. Ex.: USD");
            }
        }

        public static void ConsultaTaxaPorClienteValidate(int clienteID)
        {
            if (clienteID == 0)
            {
                throw new ArgumentException("clienteID é obrigatório");
            }
        }

        public static void ConsultaTaxaPorSegmentoValidate(string nomeSegmento)
        {
            if (string.IsNullOrEmpty(nomeSegmento))
            {
                throw new ArgumentException("nomeSegmento é obrigatório");
            }
        }
    }
}
