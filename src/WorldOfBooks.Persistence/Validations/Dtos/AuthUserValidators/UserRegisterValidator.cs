using FluentValidation;
using WorldOfBooks.Persistence.Dtos.User;

namespace WorldOfBooks.Persistence.Validations.Dtos.AuthUserValidators;

public class UserRegisterValidator : AbstractValidator<UserCreateDto>
{
    public UserRegisterValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("FirstName is required!")
            .MinimumLength(3).WithMessage("FirstName must be less than 3 characters")
                .MaximumLength(30).WithMessage("FirstName must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("LastName is required!")
            .MinimumLength(3).WithMessage("LastName must be less than 3 characters")
                .MaximumLength(30).WithMessage("LastName must be less than 30 characters");

        RuleFor(dto => dto.Phone).Must(phone => PhoneNumberValidator.IsValid(phone))
           .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
          .WithMessage("Email is not valid!");


        RuleFor(dto => dto.Password).Must(passsword => PasswordValidator.IsStrongPassword(passsword).IsValid)
            .WithMessage("The password must include uppercase and lowercase, " +
                "and numbers as well as symbols, and the total length must be more than 6 characters.");
    }
}