using FluentValidation;

namespace Demo.PatrimonyManagement.Domain.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public const string NameMessage = "O nome da marca é obrigatório.";

        public BrandValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage(NameMessage);
        }
    }
}
