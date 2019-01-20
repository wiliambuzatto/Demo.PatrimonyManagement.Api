using FluentValidation;

namespace Demo.PatrimonyManagement.Domain.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public const string EmailMessage = "O e-mail do usuário é obrigatório";
        public const string EmailFormatMessage = "O formato do e-mail do usuário é inválido.";
        public const string PasswordMessage = "A senha do usuário é obrigatória.";
        public const string NameMessage = "O nome do usuário é obrigatório.";

        public UserValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(EmailFormatMessage)
                .NotEmpty()
                .WithMessage(EmailMessage);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(NameMessage);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(PasswordMessage);
        }
    }
}
