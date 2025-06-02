using MediatR;
using TestIndt.Application.CrossCutting.DTO;

namespace TestIndt.Application.Commands.UsuarioModule.Command
{
    public class DeleteUserCommand : IRequest<ResultType>
    {
        public long Id { get; set; }
        public DeleteUserCommand(long id)
        {
            Id = id;
        }
    }
}