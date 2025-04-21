using AwingApi.Entities;
using AwingApi.Models.Request;
using AwingApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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


        [HttpPost]
        public async Task<IActionResult> AddLogSample()
        {
            CalculationLog log = new CalculationLog()
            {
                Var_N = 3,
                Var_M = 3,
                Var_P = 5,
                Result = 13 ,
                Matrix = "[[3,2,3],[1,2,4],[5,1,1]]",
                CreateAt = DateTime.Now,
            };
             await _calculatorService.AddLog(log);
            return Ok("Add successfully");
        }
    }
}
