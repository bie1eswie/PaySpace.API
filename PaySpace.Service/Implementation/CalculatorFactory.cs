using PaySpace.Common.Enums;
using PaySpace.Data.Abstract;
using PaySpace.Model.Abstract;
using PaySpace.Model.Calculator;
using PaySpace.Model.FlatRate;
using PaySpace.Model.FlatValue;
using PaySpace.Model.Progressive;
using PaySpace.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Service.Implementation
{
    public class CalculatorFactory: ICalculatorFactory
    {
        private readonly IPaySpaceRepository _paySpaceRepository;
        public CalculatorFactory(IPaySpaceRepository paySpaceRepository) 
        { 
           _paySpaceRepository = paySpaceRepository;
        }

        public async Task<ICalculator> CreateCalculator(CalculatorRequest  calculatorRequest)
        {
            var calculatorMap = await _paySpaceRepository.GetCalculatorTypeMap(calculatorRequest.PostalCode);
            if (calculatorMap == null)
            {
                throw new ArgumentNullException();
            }

            switch (calculatorMap.CalculatorType)
            {
                case CalculatorType.FlatValue:
                    return new FlatValueCalculator();
                case CalculatorType.FlatRate:
                    return new FlatRateCalculator();
                default:
                    var rangeMap = await _paySpaceRepository.GetProgressiveCalculatorRangeMap(calculatorRequest.AnnualIncome);
                    return new ProgressiveCalculator(rangeMap);
            }
        }
    }
}
