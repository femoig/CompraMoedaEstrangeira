using CompraMoedaEstrangeira.Domain.ResourceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraMoedaEstrangeira.Service
{
    public interface ISegmentoClienteService
    {
        List<SegmentoResponse> ListarTodosSegmentos();
        SegmentoResponse AtualizarTaxa(string segmento, decimal valorTaxa);

        public decimal ConsultaTaxaPorSegmento(string nomeSegmento);
    }
}
