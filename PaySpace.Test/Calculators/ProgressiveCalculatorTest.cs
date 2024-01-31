using PaySpace.Model.Progressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Test.Calculators
{
    public class ProgressiveCalculatorTest
    {
        private ProgressiveCalculator ProgressiveCalculator;
        [SetUp]
        public void SetUp() 
        {

        }

        [TestCase(950000)]
        public void Calculate_Progressive_Value_For_Value(double value) 
        {
            //setup
            ProgressiveCalculatorRangeMap progressiveCalculatorRangeMap = new ProgressiveCalculatorRangeMap()
            {
                From = 372951,
                To = double.MaxValue,
                Percentage = 0.35
            };

            ProgressiveCalculator = new ProgressiveCalculator(progressiveCalculatorRangeMap);

            //expected 
            var expectedValue = value * 0.35;
            //actual
            var result = ProgressiveCalculator.Calculate(value);

            Assert.That(expectedValue, Is.EqualTo(result));

        }
    }
}
