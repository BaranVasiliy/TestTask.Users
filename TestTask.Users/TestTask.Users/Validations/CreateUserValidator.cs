using FluentValidation;
using TestTask.Users.Commands;
using TestTask.Users.Constants;

namespace TestTask.Users.Validations
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage(ErrorMessages.ExceededMaxLength);

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage(ErrorMessages.ExceededMaxLength);

            RuleFor(a => a.DataBirth)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidDateTime);

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage(ErrorMessages.ExceededMaxLength);

            RuleFor(a => a.Phone)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidPhoneFormat);
        }
    }
}
