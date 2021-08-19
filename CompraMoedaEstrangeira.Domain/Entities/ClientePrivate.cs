using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.Entities
{
    public class ClientePrivate : Cliente
    {
        public override string NomeSegmento => "Private";
        //public override decimal ConsultaTaxa()
        //{
        //    return 5m;
        //}
    }
}
