using CompraMoedaEstrangeira.Data;
using CompraMoedaEstrangeira.Domain.ResourceModel;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CompraMoedaEstrangeira.Service.Testes
{
    public class SegmentoClienteTestes
    {
        public Mock<ISegmentoRepository> mock = new Mock<ISegmentoRepository>();
        List<SegmentoResponse> segmentos;

        [SetUp]
        public void Setup()
        {
            segmentos = new List<SegmentoResponse>
            {
                new SegmentoResponse{ NomeSegmento="Varejo", Taxa=15m },
                new SegmentoResponse{ NomeSegmento="Private", Taxa=10m },
                new SegmentoResponse{ NomeSegmento="Personnalite", Taxa=5m }
            };
        }

        [Test]
        public void ListarTodosSegmentos_ListaPreenchida()
        {
            mock.Setup(p => p.ListarSegmentos()).Returns(segmentos);
            SegmentoClienteService service = new SegmentoClienteService(mock.Object);
            var result = service.ListarTodosSegmentos();

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void AtualizaTaxaSegmento_ValorTaxaPositiva()
        {
            //arrange
            SegmentoResponse segmentoResponse = new SegmentoResponse { NomeSegmento = "Private", Taxa = 5m };

            //act
            mock.Setup(p => p.AtualizarTaxa("Private", 5m)).Returns(segmentoResponse);
            SegmentoClienteService service = new SegmentoClienteService(mock.Object);
            service.AtualizarTaxa("Private", 5m);

            //assert
            Assert.That(segmentoResponse.Taxa == 5m);
        }

        [Test]
        public void AtualizaTaxaSegmento_ValorTaxaNegativa_NaoDevePermitir()
        {
            //arrange
            SegmentoResponse segmentoResponse = new SegmentoResponse { NomeSegmento = "Private", Taxa = -3m };

            //act
            mock.Setup(p => p.AtualizarTaxa("Private", 5m)).Returns(segmentoResponse);
            SegmentoClienteService service = new SegmentoClienteService(mock.Object);

            //assert
            var ex = Assert.Throws<System.InvalidOperationException>(() => service.AtualizarTaxa("Private", -5m));
            Assert.That(ex.Message == "Valor da taxa não pode ser negativo");
        }

        [Test]
        public void ConsultaTaxaPorSegmento_Existente()
        {
            //arrange
            SegmentoResponse segmentoResponse = new SegmentoResponse { NomeSegmento = "Private", Taxa = 5m };

            //act
            mock.Setup(p => p.ConsultaTaxa("Private")).Returns(5);
            SegmentoClienteService service = new SegmentoClienteService(mock.Object);
            service.AtualizarTaxa("Private", 5m);

            //assert
            Assert.That(segmentoResponse.Taxa == 5m);
        }
    }
}