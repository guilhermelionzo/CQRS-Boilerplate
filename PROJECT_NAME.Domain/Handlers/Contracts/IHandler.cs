using PROJECT_NAME.Domain.Commands.Contracts;

namespace PROJECT_NAME.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {

    }
}