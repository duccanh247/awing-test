using AwingApi.Entities;
using AwingApi.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AwingApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly MyDbContext _dbContext;
        public CalculatorService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<float> Calculate(CalculateRequest request)
        {
            // TODO something
            CalculationLog log = new CalculationLog()
            {
                Var_N = request.Matrix.Count,
                Var_M = request.Matrix[0].Count,
                Var_P = request.P,
                Result = 111,
                Matrix = JsonSerializer.Serialize(request.Matrix),
                CreateAt = DateTime.Now,
            };
            await AddLog(log);
            return log.Result;
        }

        public async Task<List<CalculationLog>> GetLog()
        {
            return await _dbContext.CalculationLog.Take(10).OrderByDescending(x => x.CreateAt).ToListAsync();
        }

        public async Task AddLog(CalculationLog log)
        {
            _dbContext.CalculationLog.Add(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
