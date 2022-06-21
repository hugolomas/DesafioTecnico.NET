using SoftP.ApiDotNet.Application.DTOs;
using SoftP.ApiDotNet.Application.DTOs.Validations;
using SoftP.ApiDotNet.Application.Services.Interfaces;

namespace SoftP.ApiDotNet.Application.Services
{
    public class FinanceService : IFinanceService
    {
        public FinanceService()
        {

        }

        public decimal GetInterestRate(decimal interestRate)
        {
            return interestRate <= 0 ? 0.01m : interestRate /= 100;
        }

        public async Task<ResultService<decimal>> GetInvestimentResult(FinanceDTO financeDTO)
        {
         
            financeDTO.InterestRate = GetInterestRate(financeDTO.InterestRate);
            if(financeDTO == null)
            {
                return ResultService.Fail<decimal>("Objeto deve ser preenchido com valores válidos!");
            }

            var result = new FinanceDTOValidator().Validate(financeDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<decimal>("Objeto inválido.", result);
            }

            // Valor Inicial * (1 + juros) ^ Tempo
            
            financeDTO.Total = (double)financeDTO.InitialInvestiment * Math.Pow((double)(1 + financeDTO.InterestRate), financeDTO.TimeInMonths);
            if(financeDTO.MonthlyContribuition > 0)
            {
                var contribuitionTotal = ((double)financeDTO.MonthlyContribuition * (Math.Pow((double)(1 + financeDTO.InterestRate), financeDTO.TimeInMonths)-1)) / (double)financeDTO.InterestRate;
                financeDTO.Total += contribuitionTotal;
            }

            return ResultService.Ok((decimal)financeDTO.Total);
        }
    }
}
