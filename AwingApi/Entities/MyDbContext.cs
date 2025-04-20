using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AwingApi.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<CalculationLog> CalculationLog { get; set; }
    }
}
