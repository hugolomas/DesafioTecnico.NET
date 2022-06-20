using Microsoft.AspNetCore.Mvc;
using SoftP.ApiDotNet.Application.DTOs;
using SoftP.ApiDotNet.Application.Services.Interfaces;

namespace SoftP.ApiDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet("calculajuros")]
        public async Task<ActionResult> Calculajuros(decimal initialInvestiment, decimal monthlyContribuition, int timeInMonths, decimal interestRate)
        {
            var financeDto = new FinanceDTO()
            {
                InitialInvestiment = initialInvestiment,
                InterestRate = interestRate,
                TimeInMonths = timeInMonths,
                MonthlyContribuition = monthlyContribuition

            };

            var result = await _financeService.GetInvestimentResult(financeDto);
            if (result.IsSuccess)
                return Ok(result.Data?.Total);

            return BadRequest(result);
        }

        [HttpGet("/taxaJuros")]
        public async Task<ActionResult> GetInterestRate(decimal interestRate)
        {
            var result = _financeService.GetInterestRate(interestRate);

            return Ok(result);
        }
    }
}
