using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Stock.Entities;
namespace Stock.DataAccess
{
    public class StockDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1400; Database=StockDb;uid=sa;pwd=Password_123;");
        }
        public DbSet<ProductStock> ProductStocks { get; set; }
    }
}
