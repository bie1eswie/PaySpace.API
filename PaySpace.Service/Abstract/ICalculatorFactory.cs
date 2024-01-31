using PaySpace.Common.Enums;
using PaySpace.Model.Abstract;
using PaySpace.Model.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Service.Abstract
{
    public interface ICalculatorFactory
    {
        Task<ICalculator> CreateCalculator(CalculatorRequest  calculatorRequest);
    }
}
