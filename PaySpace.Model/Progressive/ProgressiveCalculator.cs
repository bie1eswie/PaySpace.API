using PaySpace.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.Progressive
{
    public class ProgressiveCalculator : ICalculator
    {
        private ProgressiveCalculatorRangeMap progressiveCalculatorRangeMap;

        public ProgressiveCalculator(ProgressiveCalculatorRangeMap progressiveCalculatorRangeMap)
        {
            this.progressiveCalculatorRangeMap = progressiveCalculatorRangeMap;
        }
        public double Calculate(double input)
        {
            return Math.Round(input * progressiveCalculatorRangeMap.Percentage);
        }
    }
}