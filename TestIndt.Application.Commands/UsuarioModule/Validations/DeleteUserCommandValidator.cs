using FluentValidation;
using TestIndt.Application.Commands.UsuarioModule.Command;

namespace TestIndt.Application.Commands.UsuarioModule.Validations
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id is required.");
        }
    }
}