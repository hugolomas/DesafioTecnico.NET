using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftP.ApiDotNet.Application.DTOs
{
    public class FinanceDTO 
    {
        public decimal InitialInvestiment { get; set; }
        public decimal MonthlyContribuition { get; set; }
        public int TimeInMonths { get; set; }
        public decimal InterestRate { get; set; }
        public string? Total { get; set; }

    }
}
