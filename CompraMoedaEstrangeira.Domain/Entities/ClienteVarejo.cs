namespace CompraMoedaEstrangeira.Domain.Entities
{
    public class ClienteVarejo : Cliente
    {
        public override string NomeSegmento => "Varejo";
        //public override decimal ConsultaTaxa()
        //{
        //    return 15m;
        //}
    }
}
