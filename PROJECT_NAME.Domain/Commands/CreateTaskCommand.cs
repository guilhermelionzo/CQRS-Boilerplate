using Flunt.Notifications;
using Flunt.Validations;
using PROJECT_NAME.Domain.Commands.Contracts;

namespace PROJECT_NAME.Domain.Commands
{
    public class CreateTaskCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                .IsNotNullOrEmpty(Name, "Name", "Name can not be null or empty.")
                );
        }
    }
}