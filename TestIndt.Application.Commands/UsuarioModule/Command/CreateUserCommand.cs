using MediatR;
using TestIndt.Application.CrossCutting.DTO;

namespace TestIndt.Application.Commands.UsuarioModule.Command
{
    public class CreateUserCommand : IRequest<ResultType>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
