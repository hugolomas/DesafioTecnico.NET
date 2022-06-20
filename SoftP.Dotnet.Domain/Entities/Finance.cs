using SoftP.ApiDotNet.Domain.Validations;

namespace SoftP.ApiDotNet.Domain.Entities
{
    public sealed class Finance
    {
        public decimal InitialInvestment { get; private set; }
        public double MonthlyContribuition { get; private set; }
        public int TimeInMonths { get; private set; }
        public double InterestRate { get; private set; }

        public Finance(decimal initialInvestiment, double monthlyContribuition, int timeInMonths, double interestRate = 0.01)
        {
            FinanceValidation(initialInvestiment, monthlyContribuition, timeInMonths, interestRate);
        }

        private void FinanceValidation(decimal initialInvestiment, double monthlyContribuition, int timeInMonths, double interestRate)
        {
            DomainValidationException.Validation( initialInvestiment <= 0, "Investimento inicial não pode ser igual ou negativa!");
            DomainValidationException.Validation( monthlyContribuition < 0, "Contrubuição mensal não pode ser negativa!");
            DomainValidationException.Validation( timeInMonths <= 0, "Tempo de investimento não pode ser igual ou menor que zero!");

            InitialInvestment = initialInvestiment;
            MonthlyContribuition = monthlyContribuition;
            TimeInMonths = timeInMonths;
            InterestRate = interestRate;
        }
    }
}
