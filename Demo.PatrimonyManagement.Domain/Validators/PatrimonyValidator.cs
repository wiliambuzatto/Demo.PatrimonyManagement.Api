using FluentValidation;

namespace Demo.PatrimonyManagement.Domain.Validators
{
    public class PatrimonyValidator : AbstractValidator<Patrimony>
    {
        public const string NameMessage = "O nome do patrimônio é obrigatório.";
        public const string BrandMessage = "É preciso associar uma marca ao patrimônio.";

        public PatrimonyValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(NameMessage);

            RuleFor(x => x.BrandId)
                .NotEmpty()
                .WithMessage(BrandMessage);
        }
    }
}
