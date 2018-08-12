using IR.Command.Notifications;
using IR.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IR.Command
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly NotificationHandler _notifications;
        private readonly IMediator _mediator;
        public CommandHandler(IUnitOfWork uow, INotificationHandler<Notification> notifications, IMediator mediator)
        {
            _uow = uow;
            _notifications = (NotificationHandler)notifications;
            _mediator = mediator;
        }

        protected bool IsValidCommand(Command message)
        {
            if (message.IsValid())
                return true;
            foreach (var error in message.ValidationResult.Errors)
            {
                _mediator.Publish(new Notification(error.PropertyName, error.ErrorMessage));
            }
            return false;
        }

        protected Task Notify(string key, string value)
        {
            _mediator.Publish(new Notification(key, value));
            return Task.CompletedTask;
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _mediator.Publish(new Notification("Commit", "Houve alguma falha ao salvar as informações."));
            return false;
        }
    }
}
