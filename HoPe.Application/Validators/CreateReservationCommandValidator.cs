using FluentValidation;
using HoPe.Application.Commands.CreateReservation;

namespace HoPe.Application.Validators
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(r => r.UserCreated)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuário é obrigatório!");

            RuleFor(r => r.Date)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data é obrigatório!");

            RuleFor(r => r.IdClient)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cliente é obrigatório!");

            RuleFor(r => r.Comment)
                .NotEmpty()
                .NotNull()
                .WithMessage("Comentário é obrigatório!");
        }
    }
}
