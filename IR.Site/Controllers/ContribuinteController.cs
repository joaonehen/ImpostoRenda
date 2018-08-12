using IR.Command.Notifications;
using IR.Service.DTOs;
using IR.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.Site.Controllers
{
    [Route("api/[controller]")]
    public class ContribuinteController : ApiController
    {
        private readonly IContribuinteService _contribuinteService;
        public ContribuinteController(IContribuinteService contribuinteService, INotificationHandler<Notification> notifications) : base(notifications)
        {
            _contribuinteService = contribuinteService;
        }

        [HttpPost("[action]")]
        public IActionResult Incluir([FromBody]ContribuinteDTO contribuinteDTO)
        {
            _contribuinteService.Incluir(contribuinteDTO);
            return Response();
        }

        [HttpGet("[action]")]
        public IActionResult CalcularImpostoRenda([FromQuery] decimal salarioMinimo)
        {
            return Response(_contribuinteService.CalcularImpostoDeRenda(salarioMinimo));
        }
    }
}
