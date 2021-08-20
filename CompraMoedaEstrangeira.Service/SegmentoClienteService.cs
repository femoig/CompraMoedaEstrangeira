using CompraMoedaEstrangeira.Data;
using CompraMoedaEstrangeira.Domain.ResourceModel;
using Service.Validators;
using System.Collections.Generic;

namespace CompraMoedaEstrangeira.Service
{
    public class SegmentoClienteService : ISegmentoClienteService
    {
        private readonly ISegmentoRepository _segmentoRepository;

        public SegmentoClienteService(ISegmentoRepository segmentoRepository)
        {
            _segmentoRepository = segmentoRepository;
        }
        public SegmentoResponse AtualizarTaxa(string segmento, decimal valorTaxa)
        {
            ValidadorAtualizarTaxa.Valida(valorTaxa);

            return _segmentoRepository.AtualizarTaxa(segmento, valorTaxa);
        }

        public List<SegmentoResponse> ListarTodosSegmentos()
        {
            return _segmentoRepository.ListarSegmentos();
        }

        public decimal ConsultaTaxaPorSegmento(string nomeSegmento)
        {
            return _segmentoRepository.ConsultaTaxa(nomeSegmento);
        }
    }
}
