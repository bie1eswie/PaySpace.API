using PaySpace.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.Calculator
{
    public class CalculatorRequest
    {
        public double AnnualIncome {  get; set; }
        public string PostalCode {  get; set; } = string.Empty;
    }
}
