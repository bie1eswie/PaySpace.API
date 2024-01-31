using PaySpace.Model.FlatRate;
using PaySpace.Model.FlatValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Test.Calculators
{
    public class FlatValueCalculatorTest
    {
        private FlatValueCalculator  FlatValueCalculator;
        [SetUp]
        public void SetUp() 
        {
            FlatValueCalculator = new FlatValueCalculator();
        }
        [TestCase(8000)]
        public void Calculate_Value_Less_The_Threshold(double value)
        {
            //Expected
            var expectedValue = value * 0.05;
            //actual
            var result = FlatValueCalculator.Calculate(value);
            //assert
            Assert.That(expectedValue, Is.EqualTo(result));
        }

        [TestCase(1800000)]
        public void Calculate_Value_Greater_The_Threshold(double value)
        {
            //Expected
            var expectedValue = value - 10000;
            //actual
            var result = FlatValueCalculator.Calculate(value);
            //assert
            Assert.That(expectedValue, Is.EqualTo(result));
        }
    }
}
