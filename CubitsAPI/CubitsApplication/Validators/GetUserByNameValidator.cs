using CubitsApplication.Contracts;
using FluentValidation;

namespace CubitsApplication.Validators
{
    public class GetUserByNameValidator : AbstractValidator<GetUserByNameRequest>
    {
        public GetUserByNameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre no es válido");
        }
    }
}