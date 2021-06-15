using Flunt.Notifications;
using PROJECT_NAME.Domain.Commands;
using PROJECT_NAME.Domain.Commands.Contracts;
using PROJECT_NAME.Domain.Handlers.Contracts;

namespace PROJECT_NAME.Domain.Handlers
{
    public class TaskHandler : Notifiable, IHandler<CreateTaskCommand>
    {
        public ICommandResult Handle(CreateTaskCommand command)
        {
            return null;
        }
    }
}