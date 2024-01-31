using Microsoft.VisualBasic;
using PaySpace.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Model.FlatValue
{
    public class FlatValueCalculator : ICalculator
    {
        public double Calculate(double input)
        {
            if(input < PaySpace.Common.Constants.Constants.FLAT_VALUE_THRESHOLD)
            {
                return Math.Round(input * PaySpace.Common.Constants.Constants.FLAT_VALUE_RATE);
            }
            else
            {
                return Math.Round(input - PaySpace.Common.Constants.Constants.FLAT_VALUE);
            }
        }
    }
}
