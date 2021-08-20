namespace CompraMoedaEstrangeiraAPI.Validators
{
    public static class ValidadorCalculadoraMoedaEstrangeira
    {
        public static bool CotacaoMoedaIsValid(string moeda, decimal valor, int clienteID)
        {
            if (string.IsNullOrEmpty(moeda) || valor == 0 || clienteID == 0)
            {
                return false;
            }

            return true;
        }

        public static bool ConsultaTaxaPorClienteIsValid(int clienteID)
        {
            if (clienteID == 0)
            {
                return false;
            }

            return true;
        }

        public static bool ConsultaTaxaPorSegmentoIsValid(string nomeSegmento)
        {
            if (string.IsNullOrEmpty(nomeSegmento))
            {
                return false;
            }

            return true;
        }
    }
}
