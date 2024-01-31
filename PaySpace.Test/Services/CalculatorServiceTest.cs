using AutoMoqCore;
using Moq;
using PaySpace.Data.Abstract;
using PaySpace.Data.Respository;
using PaySpace.Model.Calculator;
using PaySpace.Model.FlatValue;
using PaySpace.Service.Abstract;
using PaySpace.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Test.Services
{
    public class CalculatorServiceTest
    {
        private AutoMoqer _mocker;
        private  CalculatorService _calculatorService;
        private CalculatorFactory _calculatorFactory;
        private PaySpaceRepository _repository;
        private PaySpaceContext _context;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer(new Config { MockBehavior = MockBehavior.Loose });
            _calculatorService = _mocker.Create<CalculatorService>();
            _calculatorFactory = _mocker.Create<CalculatorFactory>();
        }

        [Test]
        public async Task PerformCalculation_Success_Get_Result()
        {
            var calculatorMap = new CalculatorTypeMap()
            {
                CalculatorType = Common.Enums.CalculatorType.FlatValue,
                PostalCode = "A100"
            };
            //setup
            _mocker
                    .GetMock<ICalculatorFactory>()
                    .Setup(x => x.CreateCalculator(It.IsAny<CalculatorRequest>()))
                    .ReturnsAsync(new FlatValueCalculator());
            _mocker
                    .GetMock<IPaySpaceRepository>()
                    .Setup(x => x.GetCalculatorTypeMap(It.IsAny<string>()))
                    .ReturnsAsync(calculatorMap);

            //expected
            var input = 856588;
            var expectedValue = input - 10000;

            //actual
           var result = await _calculatorService.PerformTaxCalculation(new CalculatorRequest() { PostalCode = "A100", AnnualIncome = input });
            //assert
           Assert.That(expectedValue,Is.EqualTo(result.CalculatedValue));

        }

    }
}
