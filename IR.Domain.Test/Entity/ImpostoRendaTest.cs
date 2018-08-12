using FluentAssertions;
using IR.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Domain.Test.Entity
{
    [TestClass]
    public class ImpostoRendaTest
    {

        [TestMethod]
        public void IsentoSemDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 0, 1683.56m);

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(0);
        }

        [TestMethod]
        public void IsentoComDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 1, 1928.47m);

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(0);
        }

        [TestMethod]
        public void PrimeiraAliquotaSemDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 0, 1958.47m);
            var valorImpostoEsperado = 146.88525M;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void PrimeiraAliquotaComDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 2, 3850);
            var valorImpostoEsperado = 281.595M;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void SegundaAliquotaSemDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 0, 4293);
            var valorImpostoEsperado = 643.95m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void SegundaAliquotaComDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 1, 4800);
            var valorImpostoEsperado = 712.845m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void TerceiraAliquotaSemDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 0, 5724);
            var valorImpostoEsperado = 1287.9m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void TerceiraAliquotaComDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 4, 6700);
            var valorImpostoEsperado = 1464.57m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void QuartaAliquotaSemDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 0, 8765);
            var valorImpostoEsperado = 2410.375m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }

        [TestMethod]
        public void QuartaAliquotaComDependentes()
        {
            //Arrange
            var salarioMinimo = 954;
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuinte = new Contribuinte("029.239.042-49", "Enzo Roberto Lima", 3, 9352);
            var valorImpostoEsperado = 2532.4475m;

            //Act
            impostoRenda.CalcularImpostoRendaContribuinte(contribuinte);

            //Assert
            contribuinte.ValorImpostoRenda.Should().Be(valorImpostoEsperado);
        }
    }
}
