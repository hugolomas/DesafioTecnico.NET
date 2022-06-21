using SoftP.ApiDotNet.Application.DTOs;
using SoftP.ApiDotNet.Application.Services;

namespace SoftP.ApiDotNet.Test
{
    public class FinanceTest 
    {
         private FinanceService _financeService;

         public FinanceTest()
         {
            _financeService = new FinanceService();
         }


         [Fact]
         public void Test_Return_InterestRate()
         {
             // Arrange
             var interestRate = 0;

             // Act  
             var result = _financeService.GetInterestRate(interestRate);

             // Assert  
             Assert.Equal(0.01m, result);
         }

        [Theory]
        [Trait("Return","Interest Rate")]
        [InlineData(0,0.01)]
        [InlineData(-10,0.01)]
        [InlineData(2,0.02)]
        [InlineData(3,0.03)]
        public void Test_Return_InterestRate_Theory(decimal first, decimal expected)
        {
            // Arrange
            var interestRate = first;

            // Act  
            var result = _financeService.GetInterestRate(interestRate);

            // Assert  
            Assert.Equal(expected, result);
        }

        [Fact]
         public async Task Test_Calculate_Compound_Interest_Async()
         {
             // Arrange
             var financeDTO = new FinanceDTO()
             {
                 InitialInvestiment = 100,
                 InterestRate = 1,
                 TimeInMonths = 5,
                 MonthlyContribuition = 0
             };
             // Act
             var compound = await _financeService.GetInvestimentResult(financeDTO);
             var result = string.Format("{0:0.#0}", compound.Data);
             // Assert
             Assert.Equal((105.10m).ToString(), result);
         }

        [Theory]
        [Trait("Calculate", "Compound Interest")]
        [InlineData(100, 1, 5, 0, "105,10")]
        [InlineData(2000, 1, 12, 250, "5424,28")]
        [InlineData(5000, 1, 22, 0, "6223,58")]
        [InlineData(10000, 1, 12, 1250, "27121,38")]
        public async Task Test_Calculate_Compound_Interest_Theory(decimal first, decimal second, int third, decimal forth, string expected)
        {
            // Arrange
            var financeDTO = new FinanceDTO()
            {
                InitialInvestiment = first,
                InterestRate = second,
                TimeInMonths = third,
                MonthlyContribuition = forth
            };
            // Act
            var compound = await _financeService.GetInvestimentResult(financeDTO);
            var result = string.Format("{0:0.#0}", compound.Data);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}