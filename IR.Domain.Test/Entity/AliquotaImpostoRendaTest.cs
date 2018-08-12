using FluentAssertions;
using IR.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IR.Domain.Test.Entity
{
    [TestClass]
    public class AliquotaImpostoRendaTest
    {
        [TestMethod]
        public void AliquotaErradaSemProxima()
        {
            //Arrange
            var aliquota = new AliquotaImpostoRenda(15, 5);
            var salarioMinimo = 1000;
            var rendaLiquida = 6000;

            //Act
            var valor = aliquota.ObterValorImpostoRenda(salarioMinimo, rendaLiquida);

            //Assert
            valor.Should().Be(0);
        }

        [TestMethod]
        public void AliquotaErradaComProxima()
        {
            //Arrange
            var aliquota = new AliquotaImpostoRenda(15, 5)
                .SendoProxima(new AliquotaImpostoRenda(22.5m, 7));
            var salarioMinimo = 1000;
            var rendaLiquida = 6000;

            //Act
            var valor = aliquota.ObterValorImpostoRenda(salarioMinimo, rendaLiquida);
            var valorEsperado = ((rendaLiquida * 22.5m) / 100);

            //Assert
            valor.Should().Be(valorEsperado);
        }

        [TestMethod]
        public void AliquotaCorretaSemProxima()
        {
            //Arrange
            var aliquota = new AliquotaImpostoRenda(15, 5);
            var salarioMinimo = 1000;
            var rendaLiquida = 4000;

            //Act
            var valor = aliquota.ObterValorImpostoRenda(salarioMinimo, rendaLiquida);
            var valorEsperado = ((rendaLiquida * 15) / 100);

            //Assert
            valor.Should().Be(valorEsperado);
        }

        [TestMethod]
        public void AliquotaMaxima()
        {
            //Arrange
            var aliquota = new AliquotaImpostoRenda(27.5m);
            var salarioMinimo = 1000;
            var rendaLiquida = 40000;

            //Act
            var valor = aliquota.ObterValorImpostoRenda(salarioMinimo, rendaLiquida);
            var valorEsperado = ((rendaLiquida * 27.5m) / 100);

            //Assert
            valor.Should().Be(valorEsperado);
        }

        [TestMethod]
        public void AliquotaCorretaComProxima()
        {
            //Arrange
            var aliquota = new AliquotaImpostoRenda(15, 5)
                .SendoProxima(new AliquotaImpostoRenda(22.5m, 7));
            var salarioMinimo = 1000;
            var rendaLiquida = 4000;

            //Act
            var valor = aliquota.ObterValorImpostoRenda(salarioMinimo, rendaLiquida);
            var valorEsperado = ((rendaLiquida * 15) / 100);

            //Assert
            valor.Should().Be(valorEsperado);
        }
    }
}
