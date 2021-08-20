﻿using CompraMoedaEstrangeira.Domain.ResourceModel;
using CompraMoedaEstrangeira.Service;
using CompraMoedaEstrangeiraAPI.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CompraMoedaEstrangeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraMoedaEstrangeiraController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculadoraMoedaEstrangeiraController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Cotação da compra de moeda estrangeira pelo cliente
        /// </summary>
        /// <param name="moeda">Moeda desejada</param>
        /// <param name="valor">Quantidade da moeda desejada</param>
        /// <param name="clienteID">Identificação do cliente</param>
        /// <returns>Cotação da moeda desejada</returns>
        [Route("CotacaoMoeda")]
        [HttpGet]
        public ActionResult<CotacaoResponse> CotacaoMoeda(string moeda, decimal valor, int clienteID)
        {
            if (!ValidadorCalculadoraMoedaEstrangeira.CotacaoMoedaIsValid(moeda, valor, clienteID))
            {
                throw new ArgumentException("Os campos [moeda,valor,clienteID] são obrigatórios");
            }

            var cotacao = _calculadoraService.CalculaCotacao(moeda, valor, clienteID);
            return cotacao;
        }

        /// <summary>
        /// Consulta da taxa cobrada do cliente
        /// </summary>
        /// <param name="clienteID">Identificação do cliente</param>
        /// <returns></returns>
        [Route("ConsultaTaxaPorCliente")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ConsultaTaxaResponse> ConsultaTaxaPorCliente(int clienteID)
        {
            if (!ValidadorCalculadoraMoedaEstrangeira.ConsultaTaxaPorClienteIsValid(clienteID))
            {
                throw new ArgumentException("clienteID é obrigatório.");
            }

            var valorTaxa = _calculadoraService.ConsultaTaxa(clienteID);

            return valorTaxa;
        }

        /// <summary>
        /// Consulta da taxa cobrada do cliente por segmento
        /// </summary>
        /// <param name="nomeSegmento">Varejo, Private, Personnalite, etc...</param>
        /// <returns></returns>
        [Route("ConsultaTaxaPorSegmento")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ConsultaTaxaResponse> ConsultaTaxaPorSegmento(string nomeSegmento)
        {
            if (!ValidadorCalculadoraMoedaEstrangeira.ConsultaTaxaPorSegmentoIsValid(nomeSegmento))
            {
                throw new ArgumentException("Nome do segmento é obrigatório.");
            }

            var valorTaxa = _calculadoraService.ConsultaTaxaPorSegmento(nomeSegmento);

            return valorTaxa;
        }
    }
}
