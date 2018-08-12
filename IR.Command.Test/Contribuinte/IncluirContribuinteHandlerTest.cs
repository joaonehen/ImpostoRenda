using IR.Command.Notifications;
using IR.Domain.Interface;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IR.Command.Test
{
    [TestClass]
    public class IncluirContribuinteHandlerTest
    {
        private readonly IContribuinteRepository _contribuinteRepository;
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler<Notification> _notifications;
        private readonly IMediator _mediator;

        public IncluirContribuinteHandlerTest()
        {
            _contribuinteRepository = Substitute.For<IContribuinteRepository>();
            _uow = Substitute.For<IUnitOfWork>();
            _notifications = new NotificationHandler();
            _mediator = Substitute.For<IMediator>();
        }

        [TestMethod]
        public void NotificacaoInconsistenciasCPF()
        {
            //Arrange
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand(string.Empty, "Diego Matheus Porto", 1, 3600);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.ReceivedWithAnyArgs(4).Publish((INotification)null);
        }

        [TestMethod]
        public void NotificacaoInconsistenciasNome()
        {
            //Arrange
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand("448.028.616-05", string.Empty, 4, 7800);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.ReceivedWithAnyArgs(2).Publish((INotification)null);
        }

        [TestMethod]
        public void NotificacaoInconsistenciasNumeroDependentes()
        {
            //Arrange
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand("448.028.616-05", "Diego Matheus Porto", -1211, 0);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.ReceivedWithAnyArgs(1).Publish((INotification)null);
        }

        [TestMethod]
        public void NotificacaoInconsistenciasRendaBrutaMensal()
        {
            //Arrange
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand("448.028.616-05", "Diego Matheus Porto", 0, -165465);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.ReceivedWithAnyArgs(1).Publish((INotification)null);
        }

        [TestMethod]
        public void NotificacaoCpfJaCadastrado()
        {
            //Arrange
            var cpf = "448.028.616-05";
            _contribuinteRepository.IsCpfRegistered(cpf).Returns(true);
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand(cpf, "Diego Matheus Porto", 2, 2335);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.ReceivedWithAnyArgs(1).Publish((INotification)null);
        }

        [TestMethod]
        public void ContribuinteAdicionado()
        {
            //Arrange
            var handler = new IncluirContribuinteHandler(_uow, _notifications, _mediator, _contribuinteRepository);
            var command = new IncluirContribuinteCommand("448.028.616-05", "Diego Matheus Porto", 2, 5968);
            _uow.Commit().Returns(true);
            //Act
            handler.Handle(command, new CancellationToken(false));
            //Assert
            _mediator.DidNotReceiveWithAnyArgs().Publish((INotification)null);
        }
    }
}
