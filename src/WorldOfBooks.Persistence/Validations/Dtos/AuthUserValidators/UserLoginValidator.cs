using FluentValidation;
using WorldOfBooks.Persistence.Dtos.Auth;

namespace WorldOfBooks.Persistence.Validations.Dtos.AuthUserValidators;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(dto => dto.Login).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");
        RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Password is required!");
    }
}
