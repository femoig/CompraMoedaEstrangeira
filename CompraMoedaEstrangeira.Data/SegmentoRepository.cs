using CompraMoedaEstrangeira.Domain.ResourceModel;
using System.Collections.Generic;

namespace CompraMoedaEstrangeira.Data
{
    public class SegmentoRepository : ISegmentoRepository
    {
        Dictionary<string, decimal> _segmentosFake = new Dictionary<string, decimal>();

        public SegmentoRepository()
        {
            _segmentosFake.Add("Varejo", 15);
            _segmentosFake.Add("Private", 10);
            _segmentosFake.Add("Personnalite", 5);
        }

        public SegmentoResponse AtualizarTaxa(string segmento, decimal valorTaxa)
        {
            if (_segmentosFake.ContainsKey(segmento))
            {
                _segmentosFake[segmento] = valorTaxa;
            }

            return new SegmentoResponse { NomeSegmento = segmento, Taxa = valorTaxa };
        }

        public decimal ConsultaTaxa(string nomeSegmento)
        {
            decimal taxa = 0;
            if (_segmentosFake.ContainsKey(nomeSegmento))
            {
                taxa = _segmentosFake[nomeSegmento];
            }

            return taxa;
        }

        public List<SegmentoResponse> ListarSegmentos()
        {
            List<SegmentoResponse> listaSegmentos = new List<SegmentoResponse>();

            foreach (var segmento in _segmentosFake)
            {
                var segmentoResponse = new SegmentoResponse { NomeSegmento = segmento.Key, Taxa = segmento.Value };
                listaSegmentos.Add(segmentoResponse);
            }

            return listaSegmentos;
        }
    }
}
