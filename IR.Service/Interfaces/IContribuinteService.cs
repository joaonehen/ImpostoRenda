using AutoMapper;
using IR.Domain.Interface;
using IR.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Service.Interfaces
{
    public interface IContribuinteService
    {
        void Incluir(ContribuinteDTO contribuinteDTO);
        List<ContribuinteDTO> CalcularImpostoDeRenda(decimal salarioMinimo);
    }
}
