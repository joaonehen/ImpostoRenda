using AutoMapper;
using IR.Command;
using IR.Service.DTOs;

namespace IR.Service.AutoMapper
{
    internal class DTOToEntityProfile : Profile
    {
        public DTOToEntityProfile()
        {
            CreateMap<ContribuinteDTO, IncluirContribuinteCommand>().ConstructUsing(c => new IncluirContribuinteCommand(c.CPF, c.Nome, c.NumeroDependentes, c.RendaBrutaMensal));
        }
    }
}