using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Service.AutoMapper
{
    public class AutoMapperConfigure
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDTOProfile());
                cfg.AddProfile(new DTOToEntityProfile());
            });
        }
    }
}
