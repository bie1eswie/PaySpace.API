using PaySpace.Model.FlatRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Test.Calculators
{
    public class FlatRateCalculatorTest
    {
        private FlatRateCalculator FlatRateCalculator;

        [SetUp] public void SetUp() {  FlatRateCalculator = new FlatRateCalculator(); }

        [TestCase(800000)]
        public void Calculate_The_Flate_Rate_Of_Value(double value)
        {
            //expected
            var expectedValue = value * 0.17;
            //actual value 
            var result = FlatRateCalculator.Calculate(value);
            //assert
            Assert.That(expectedValue, Is.EqualTo(result));
        }
    }
}
