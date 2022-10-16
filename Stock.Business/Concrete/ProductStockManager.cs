using Stock.Business.Abstract;
using Stock.DataAccess;
using Stock.DataAccess.Abstract;
using Stock.DataAccess.Concrete;
using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business.Concrete
{
    public class ProductStockManager : IProductStockService
    {
        private IProductStockRepository _productStockRepository;


        public ProductStockManager(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;

        } 
        public async Task<ProductStock> CreateProductStock(ProductStock productStock)
        {
            return await _productStockRepository.CreateProductStock(productStock);
        }


        public async Task<List<ProductStock>> GetAllProductStocks()
        {
            return await _productStockRepository.GetAllProductStocks();
        }

        public async Task<ProductStock> GetProductStockById(int id)
        {
            if(id > 0)
            {
                return await _productStockRepository.GetProductStockById(id);

            }
            throw new Exception("id can not be less than 1");
        }

        public async Task<ProductStock> GetProductStockByProductCode(string productCode)
        {
            return await _productStockRepository.GetProductStockByProductCode(productCode);
        }

        public async Task<ProductStock> GetProductStockByVariantCode(string variantCode)
        {
            return await _productStockRepository.GetProductStockByVariantCode(variantCode);
        }

    }
}
