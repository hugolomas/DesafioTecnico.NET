using SoftP.ApiDotNet.Application.DTOs;
using SoftP.ApiDotNet.Domain.Entities;

namespace SoftP.ApiDotNet.Application.Services.Interfaces
{
    public interface IFinanceService
    {
        Task<ResultService<decimal>> GetInvestimentResult(FinanceDTO finance);

        decimal GetInterestRate(decimal interestRate);
    }
}
