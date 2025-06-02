using FluentValidation;
using MediatR;
using TestIndt.Application.Commands.UsuarioModule.Command;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Domain.Entities;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Commands.UsuarioModule.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultType>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IUserRepository userRepository, IValidator<CreateUserCommand> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<ResultType> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {                
                throw new ValidationException(validationResult.Errors);
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,              
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return new ResultType { Success = true, Data = user };
        }
    }
}
