using AutoMapper;
using IR.Domain.Entity;
using IR.Service.DTOs;

namespace IR.Service.AutoMapper
{
    internal class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<Contribuinte, ContribuinteDTO>();
        }
    }
}