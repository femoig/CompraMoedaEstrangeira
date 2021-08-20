using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Domain.ResourceModel
{
    public class CotacaoResponse
    {
        public decimal ValorCotacao { get; set; }

        public string MoedaOrigem { get { return "BRL"; } }

        public string MoedaDesejada { get; set; }
                
        public decimal ValorDesejado { get; set; }

        public decimal ValorTaxaSegmento { get; set; }

        public decimal ValorCambio { get; set; }

        public string NomeSegmento { get; set; }
        public int ClienteID { get; set; }

        public string Erro { get; set; }



    }
}
