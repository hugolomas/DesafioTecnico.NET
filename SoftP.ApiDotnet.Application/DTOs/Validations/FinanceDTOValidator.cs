using FluentValidation;

namespace SoftP.ApiDotNet.Application.DTOs.Validations
{
    public class FinanceDTOValidator : AbstractValidator<FinanceDTO>
    {
        public FinanceDTOValidator()
        {
            RuleFor(x => x.InitialInvestiment)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O valor inicial de investimendo deve ser informado ou maior que zero!");

            RuleFor(x => x.TimeInMonths)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("A quantidade de meses deve ser informada e maior que zero!");

            RuleFor(x => x.MonthlyContribuition)
                .GreaterThanOrEqualTo(0)
                .WithMessage("A contribuição mensal não pode ser negativa;");

        }
    }
}
