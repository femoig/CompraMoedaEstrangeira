using CompraMoedaEstrangeira.Domain.ResourceModel;
using System.Collections.Generic;

namespace CompraMoedaEstrangeira.Service
{
    public interface ISegmentoClienteService
    {
        List<SegmentoResponse> ListarTodosSegmentos();
        SegmentoResponse AtualizarTaxa(string segmento, decimal valorTaxa);

        public decimal ConsultaTaxaPorSegmento(string nomeSegmento);
    }
}
