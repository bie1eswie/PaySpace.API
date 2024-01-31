using Microsoft.AspNetCore.Mvc;
using PaySpace.API.Abstract;
using PaySpace.Model.Calculator;
using PaySpace.Service.Abstract;

namespace PaySpace.API.Controllers
{
    public class CalculatorController : ApiControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        [HttpPost]

        public async Task<IActionResult> Calculate(CalculatorRequest calculatorRequest)
        {
            try
            {
                var response = await _calculatorService.PerformTaxCalculation(calculatorRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("500 - Internal Server Error");
            }
        }
    }
}
