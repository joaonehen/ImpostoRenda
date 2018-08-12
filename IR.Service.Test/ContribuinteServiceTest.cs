using AutoMapper;
using FluentAssertions;
using IR.Domain.Entity;
using IR.Domain.Interface;
using IR.Service.AutoMapper;
using IR.Service.Classes;
using IR.Service.DTOs;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace IR.Service.Test
{
    [TestClass]
    public class ContribuinteServiceTest
    {
        private readonly IMapper _mapper;
        private readonly IContribuinteRepository _contribuinteRepository;
        private readonly IMediator _mediator;

        public ContribuinteServiceTest()
        {
            _mapper = new Mapper(AutoMapperConfigure.Configure());
            _mediator = Substitute.For<IMediator>();
            _contribuinteRepository = Substitute.For<IContribuinteRepository>();

        }

        [TestMethod]
        public void MetodoIncluir()
        {
            //Arrange
            var service = new ContribuinteService(_mapper, _contribuinteRepository, _mediator);
            var contribuinteDTO = new ContribuinteDTO();
            //Act
            service.Incluir(contribuinteDTO);
        }

        [TestMethod]
        public void CalcularImpostoRendaVariasAliquotas()
        {
            //Arrange
            var contribuintes = new List<Contribuinte>()
            {
                new Contribuinte("066.349.687-05","Valentina Sophia Teixeira",0,4293),
                new Contribuinte("893.888.821-56","Tiago Juan Pietro Assunção",0,1683.56m),
                new Contribuinte("329.823.847-36","Patrícia Joana Ferreira",4,6700),
                new Contribuinte("048.972.533-30","Mário Thomas Isaac Martins",0,8765),
                new Contribuinte("889.218.837-20","Fábio Theo Silva",0,5724),
                new Contribuinte("443.527.675-57","Milena Isis Baptista",0,1958.47m),
                new Contribuinte("230.434.267-11","Marcos Pedro Henrique Henrique Baptista",4,6700),
            };
            _contribuinteRepository.GetAll().Returns(contribuintes);
            var service = new ContribuinteService(_mapper, _contribuinteRepository, _mediator);
            var salarioMinimo = 954m;
            //Act
            var contribuintesRetorno = service.CalcularImpostoDeRenda(salarioMinimo);
            //Assert
            contribuintesRetorno.Should().BeInAscendingOrder(x => x.ValorImpostoRenda);
            contribuintesRetorno.GroupBy(x => x.ValorImpostoRenda).ToList().ForEach(x =>
              {
                  x.ToList().Should().BeInAscendingOrder(c => c.Nome);
              });
        }

        [TestMethod]
        public void CalcularImpostoRendaValoresIguais()
        {
            //Arrange
            var contribuintes = new List<Contribuinte>()
            {
                new Contribuinte("066.349.687-05","Valentina Sophia Teixeira",0,2600),
                new Contribuinte("893.888.821-56","Tiago Juan Pietro Assunção",0,2600),
                new Contribuinte("329.823.847-36","Patrícia Joana Ferreira",0,2600),
                new Contribuinte("048.972.533-30","Mário Thomas Isaac Martins",0,2600),
                new Contribuinte("889.218.837-20","Fábio Theo Silva",0,2600),
                new Contribuinte("443.527.675-57","Milena Isis Baptista",0,2600),
                new Contribuinte("230.434.267-11","Marcos Pedro Henrique Henrique Baptista",0,2600),
            };
            _contribuinteRepository.GetAll().Returns(contribuintes);
            var service = new ContribuinteService(_mapper, _contribuinteRepository, _mediator);
            var salarioMinimo = 954m;
            var valorImposto = 195m;
            //Act
            var contribuintesRetorno = service.CalcularImpostoDeRenda(salarioMinimo);
            //Assert
            contribuintesRetorno.Should().BeInAscendingOrder(x => x.Nome);
            contribuintesRetorno.Should().Match(x => x.All(c => c.ValorImpostoRenda == valorImposto));
        }
    }
}
