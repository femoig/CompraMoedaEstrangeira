using CompraMoedaEstrangeira.Domain.ResourceModel;
using CompraMoedaEstrangeira.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraMoedaEstrangeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SegmentoClienteController : ControllerBase
    {
        private readonly ISegmentoClienteService _segmentoClienteService;

        public SegmentoClienteController(ISegmentoClienteService segmentoClienteService)
        {
            _segmentoClienteService = segmentoClienteService;
        }

        /// <summary>
        /// Lista todos segmentos disponíveis
        /// </summary>
        /// <returns>Nome do segmento e valor da taxa</returns>
        [Route("ListarSegmentos")]
        [HttpGet]
        public ActionResult<List<SegmentoResponse>> ListarSementos()
        {
            return _segmentoClienteService.ListarTodosSegmentos();
        }

        /// <summary>
        /// Atualizar valor da taxa por segmento
        /// </summary>
        /// <param name="segmento">Tipo do segmento. Ex.: Private, Personnalite, Varejo</param>
        /// <param name="valorTaxa">Novo valor da taxa</param>
        [Route("AtualizaTaxaSegmento")]
        [HttpGet]
        public ActionResult<SegmentoResponse> AtualizaTaxaSegmento(string segmento, decimal valorTaxa)
        {
            return _segmentoClienteService.AtualizarTaxa(segmento, valorTaxa);
        }
    }
}
