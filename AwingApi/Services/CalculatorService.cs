using AwingApi.Entities;
using AwingApi.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AwingApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly MyDbContext _dbContext;
        public CalculatorService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<double> Calculate(CalculateRequest request)
        {
            // TODO something

            // validate

            // calculate

            var allPositions = new List<NumberInfo>();
            // var allPositions1 = new Dictionary<(int, int), int>();


            for (int i = 0; i < request.Matrix.Count; i++)
            {
                for (int j = 0; j < request.Matrix[i].Count; j++)
                {
                    var numberInfo = new NumberInfo()
                    {
                        X = i + 1,
                        Y = j + 1,
                        Value = request.Matrix[i][j]
                    };
                    allPositions.Add(numberInfo);
                    // allPositions1.Add((i, j), request.Matrix[i][j]);
                }
            }

            double totalDist = 0;
            var firstPoint = allPositions.First(x => x.X == 1 && x.Y == 1);
            var currentPos = new NumberInfo() { X = 1, Y = 1, Value = request.Matrix[0][0] };

            // Truong hop p = n*m
            if (request.P == request.Matrix.Count * request.Matrix[0].Count)
            {
                for (int i = 1; i <= request.P; i++)
                {
                    if (i == 1 && firstPoint.Value == 1)
                    {
                        continue;
                    }
                    var pos = allPositions.First(x => x.Value == i);
                    var dis = CalculateDistance(currentPos, pos);
                    currentPos = pos;
                    totalDist += dis;
                }
            }
            var endPos = allPositions.First(x => x.Value == request.P);

            // Truong hop khac
            for (int k = 1; k <= request.P; k++)
            {
                if (k == 1 && firstPoint.Value == 1)
                {
                    continue;
                }
                var postionK = allPositions.Where(x => x.Value == k).ToList();
                double minDis = 0;
                NumberInfo selectPoint = currentPos;
                foreach (NumberInfo point in postionK)
                {
                    var disC = CalculateDistance(point, currentPos);
                    var disE = CalculateDistance(point, endPos);
                    if (minDis == 0)
                    {
                        minDis = disC + disE;
                        selectPoint = point;
                    }
                    if (minDis > 0 && (disC + disE) < minDis)
                    {
                        minDis = disC + disE;
                        selectPoint = point;
                    }
                }
                currentPos = selectPoint;
                totalDist += minDis;
                Console.WriteLine("Point: " + k + ", XY: " + selectPoint.X.ToString() + " " + selectPoint.Y.ToString());
            }

            CalculationLog log = new CalculationLog()
            {
                Var_N = request.Matrix.Count,
                Var_M = request.Matrix[0].Count,
                Var_P = request.P,
                Result = totalDist,
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
        public static double CalculateDistance(NumberInfo point1, NumberInfo point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }

    public class NumberInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
}
