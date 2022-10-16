using Microsoft.EntityFrameworkCore;
using Stock.DataAccess.Abstract;
using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.DataAccess.Concrete
{
    public class ProductStockRepository : IProductStockRepository
    {

        public async Task<ProductStock> CreateProductStock(ProductStock productStock)
        {
            using (var stockDbContext = new StockDbContext())
            {
                stockDbContext.ProductStocks.Add(productStock);
                await stockDbContext.SaveChangesAsync();
                return productStock;
            }
        }

        public async Task<List<ProductStock>> GetAllProductStocks()
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.ProductStocks.ToListAsync();
            }
        }

        public async Task<ProductStock> GetProductStockById(int id)
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.ProductStocks.FindAsync(id);

            }
        }

        public async Task<ProductStock> GetProductStockByProductCode(string productCode)
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.ProductStocks.FirstOrDefaultAsync(x => x.ProductCode == productCode);
            }
        }

        public async Task<ProductStock> GetProductStockByVariantCode(string variantCode)
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.ProductStocks.FirstOrDefaultAsync(x => x.VariantCode == variantCode);
            }
        }


    }
}
