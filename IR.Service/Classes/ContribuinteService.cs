using AutoMapper;
using IR.Command;
using IR.Domain.Entity;
using IR.Domain.Interface;
using IR.Service.DTOs;
using IR.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IR.Service.Classes
{
    public class ContribuinteService : IContribuinteService
    {
        private readonly IMapper _mapper;
        private readonly IContribuinteRepository _contribuinteRepository;
        private readonly IMediator _mediator;

        public ContribuinteService(IMapper mapper, IContribuinteRepository contribuinteRepository, IMediator mediator)
        {
            _mapper = mapper;
            _contribuinteRepository = contribuinteRepository;
            _mediator= mediator;
        }

        public List<ContribuinteDTO> CalcularImpostoDeRenda(decimal salarioMinimo)
        {
            var impostoRenda = new ImpostoRenda(salarioMinimo);
            var contribuintes = _contribuinteRepository.GetAll();
            contribuintes.ForEach(x => impostoRenda.CalcularImpostoRendaContribuinte(x));
            contribuintes = contribuintes.OrderBy(x => x.ValorImpostoRenda).ThenBy(x => x.Nome).ToList();
            return _mapper.Map<List<ContribuinteDTO>>(contribuintes);
        }

        public void Incluir(ContribuinteDTO contribuinteDTO)
        {
            var command = _mapper.Map<IncluirContribuinteCommand>(contribuinteDTO);
            _mediator.Send(command);
        }
    }
}
