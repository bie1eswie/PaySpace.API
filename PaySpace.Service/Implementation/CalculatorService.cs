using PaySpace.Data.Abstract;
using PaySpace.Model.Calculator;
using PaySpace.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Service.Implementation
{
    public class CalculatorService: ICalculatorService
    {
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly IPaySpaceRepository _paySpaceRepository;
        public CalculatorService(ICalculatorFactory calculatorFactory, IPaySpaceRepository paySpaceRepository) 
        { 
            _calculatorFactory = calculatorFactory;
            _paySpaceRepository = paySpaceRepository;
        }

        public async Task<CalculatorResponse> PerformTaxCalculation(CalculatorRequest calculatorRequest)
        {
            var calculator = await _calculatorFactory.CreateCalculator(calculatorRequest);
            var result = calculator.Calculate(calculatorRequest.AnnualIncome);
            var calculatorResponse = new CalculatorResponse()
            {
                AnnualIncome = calculatorRequest.AnnualIncome,
                PostalCode = calculatorRequest.PostalCode,
                CalculatedValue = result,
                DateTime = DateTime.UtcNow
            };

            await _paySpaceRepository.CreateCalculatorResponse(calculatorResponse);
            return calculatorResponse;
        }
    }
}
