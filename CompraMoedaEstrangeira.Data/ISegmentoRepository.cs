using CompraMoedaEstrangeira.Domain.ResourceModel;
using System.Collections.Generic;

namespace CompraMoedaEstrangeira.Data
{
    public interface ISegmentoRepository
    {
        List<SegmentoResponse> ListarSegmentos();
        SegmentoResponse AtualizarTaxa(string segmento, decimal valorTaxa);
        decimal ConsultaTaxa(string nomeSegmento);
    }
}