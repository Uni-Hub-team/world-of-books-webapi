using FluentValidation;
using WorldOfBooks.Persistence.Dtos.Auth;

namespace WorldOfBooks.Persistence.Validations.Dtos.AuthUserValidators;

public class UserLoginValidatorWithEmail : AbstractValidator<UserLoginDto>
{
    public UserLoginValidatorWithEmail()
    {
        RuleFor(dto => dto.Login).Must(email => EmailValidator.IsValid(email))
            .WithMessage("Email is not valid!");
        RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Password is required!");
    }
}
