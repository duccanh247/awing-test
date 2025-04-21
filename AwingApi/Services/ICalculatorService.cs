using AwingApi.Entities;
using AwingApi.Models.Request;

namespace AwingApi.Services
{
    public interface ICalculatorService
    {
        Task<List<CalculationLog>> GetLog();
        Task AddLog(CalculationLog log);
        Task<double> Calculate(CalculateRequest request);
    }
}
