using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.Entities
{    
    public class ClientePersonnalite : Cliente
    {
        public override string NomeSegmento => "Personnalite";

        
        //public override decimal ConsultaTaxa()
        //{
        //    return 10m;
        //}
    }
}
