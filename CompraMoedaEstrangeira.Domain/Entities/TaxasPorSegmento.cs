using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.Entities
{
    public class TaxasPorSegmento
    {
        public string NomeSegmento { get; set; }
        public decimal ValorTaxa { get; set; }
    }
}
