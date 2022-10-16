﻿using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business.Abstract
{
    public interface IProductStockService
    {
        Task<List<ProductStock>> GetAllProductStocks();

        Task<ProductStock> GetProductStockById(int id);
        Task<ProductStock> GetProductStockByVariantCode(string variantCode);
        Task<ProductStock> GetProductStockByProductCode(string productCode);
        Task<ProductStock> CreateProductStock(ProductStock productStock);


    }
}
