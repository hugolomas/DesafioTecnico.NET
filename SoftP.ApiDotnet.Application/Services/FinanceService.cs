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

        public async Task<ResultService<FinanceDTO>> GetInvestimentResult(FinanceDTO financeDTO)
        {
         
            financeDTO.InterestRate = GetInterestRate(financeDTO.InterestRate);
            if(financeDTO == null)
            {
                return ResultService.Fail<FinanceDTO>("Objeto deve ser preenchido com valores válidos!");
            }

            var result = new FinanceDTOValidator().Validate(financeDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<FinanceDTO>("Objeto inválido.", result);
            }

            // Valor Inicial * (1 + juros) ^ Tempo
          
            financeDTO.Total = string.Format("{0:0.##}", (double)financeDTO.InitialInvestiment * Math.Pow((double)(1 + financeDTO.InterestRate), (double)financeDTO.TimeInMonths));
            //return result não a classe.
            var resultService = ResultService.Ok(financeDTO);

            return resultService;
        }
    }
}
