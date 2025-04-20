using AwingApi.Models.Request;
using AwingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwingApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLog()
        {
            var logs = await _calculatorService.GetLog();
            return Ok(logs);
        }


        [HttpPost]
        public async Task<IActionResult> Calculate(CalculateRequest request)
        {
            var rs = await _calculatorService.Calculate(request);
            return Ok(rs);
        }
    }
}
