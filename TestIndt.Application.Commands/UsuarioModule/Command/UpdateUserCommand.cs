using MediatR;
using TestIndt.Application.CrossCutting.DTO;

namespace TestIndt.Application.Commands.UsuarioModule.Command
{
    public class UpdateUserCommand : IRequest<ResultType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}