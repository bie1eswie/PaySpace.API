using Microsoft.VisualBasic;
using PaySpace.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.FlatRate
{
    public class FlatRateCalculator : ICalculator
    {
        public double Calculate(double input)
        {
            return Math.Round(input * PaySpace.Common.Constants.Constants.FLAT_RATE);
        }
    }
}
