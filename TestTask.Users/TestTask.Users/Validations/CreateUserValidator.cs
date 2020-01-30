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
                .MaximumLength(50).WithMessage(ErrorMessagesConstatnts.ExceededMaxLength)
                .Matches("[A-Z]")
                .Matches("[a-z]").WithMessage(ErrorMessagesConstatnts.InvalidNameFormat);

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MaximumLength(50).WithMessage(ErrorMessagesConstatnts.ExceededMaxLength)
                .Matches("[A-Z]")
                .Matches("[a-z]").WithMessage(ErrorMessagesConstatnts.InvalidLastNameFormat); ;

            RuleFor(a => a.DataBirth)
                .NotEmpty()
                .WithMessage(ErrorMessagesConstatnts.InvalidDateTime);

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage(ErrorMessagesConstatnts.ExceededMaxLength)
                .EmailAddress();

            RuleFor(a => a.Phone)
                .NotEmpty().WithMessage(ErrorMessagesConstatnts.InvalidPhoneFormat)
                .Matches("[0-9]").WithMessage(ErrorMessagesConstatnts.InvalidPhoneFormat);

        }
    }
}