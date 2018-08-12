using IR.Command.Notifications;
using IR.Domain.Entity;
using IR.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IR.Command
{
    public class IncluirContribuinteHandler : CommandHandler, IRequestHandler<IncluirContribuinteCommand>
    {
        private readonly IContribuinteRepository _contribuinteRepository;
        public IncluirContribuinteHandler(IUnitOfWork uow, INotificationHandler<Notification> notifications, IMediator mediator, IContribuinteRepository contribuinteRepository) : base(uow, notifications, mediator)
        {
            _contribuinteRepository = contribuinteRepository;
        }

        public Task Handle(IncluirContribuinteCommand request, CancellationToken cancellationToken)
        {
            if (!IsValidCommand(request))
                return Task.CompletedTask;

            if (_contribuinteRepository.IsCpfRegistered(request.CPF))
                return Notify(nameof(request.CPF), "Cpf já cadastrado.");

            var contribuinte = new Contribuinte(request.CPF, request.Nome, request.NumeroDependentes, request.RendaBrutaMensal);

            _contribuinteRepository.Add(contribuinte);

            Commit();

            return Task.CompletedTask;
        }
    }
}
