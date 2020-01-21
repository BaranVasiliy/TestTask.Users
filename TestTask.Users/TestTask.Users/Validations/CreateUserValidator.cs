using System.Text.RegularExpressions;
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
                .MaximumLength(50).WithMessage(ErrorMessages.ExceededMaxLength)
                .Matches("[A-Z]")
                .Matches("[a-z]").WithMessage(ErrorMessages.InvalidNameFormat);

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MaximumLength(50).WithMessage(ErrorMessages.ExceededMaxLength)
                .Matches("[A-Z]")
                .Matches("[a-z]").WithMessage(ErrorMessages.InvalidLastNameFormat); ;

            RuleFor(a => a.DataBirth)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidDateTime);

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage(ErrorMessages.ExceededMaxLength)
                .EmailAddress();

            RuleFor(a => a.Phone)
                .NotEmpty().WithMessage(ErrorMessages.InvalidPhoneFormat)
                .Matches("[0-9]").WithMessage(ErrorMessages.InvalidPhoneFormat);

        }
    }
}