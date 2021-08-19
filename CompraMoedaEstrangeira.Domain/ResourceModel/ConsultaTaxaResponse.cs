using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.ResourceModel
{
    public class ConsultaTaxaResponse
    {
        public decimal ValorTaxa { get; set; }
        public string NomeSegmento { get; set; }
    }
}
