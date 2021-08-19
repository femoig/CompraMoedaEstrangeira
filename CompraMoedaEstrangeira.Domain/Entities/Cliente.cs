using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.Entities
{
    public abstract class Cliente
    {
        //public abstract decimal ConsultaTaxa();


        public abstract string NomeSegmento
        {
            get;
        }
    }
}
