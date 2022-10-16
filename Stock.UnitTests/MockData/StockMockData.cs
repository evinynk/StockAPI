using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.UnitTests.MockData
{
    public class StockMockData
    {
        public static List<ProductStock> GetStocks()
        {
            return new List<ProductStock>
            {

                new ProductStock
                {
                    Id=12,
                    ProductCode="1052",
                    VariantCode="100000102",
                    Quantity=4
                },
                new ProductStock
                {
                    Id=13,
                    ProductCode="1053",
                    VariantCode="100000103",
                    Quantity=12
                },
                new ProductStock
                {
                    Id=14,
                    ProductCode="1054",
                    VariantCode="100000104",
                    Quantity=9
                },
            };  
        }
        public static List<ProductStock> EmptyStocks()
        {
            return new List<ProductStock>();
        }

        public static ProductStock CreateProductStock()
        {
            return new ProductStock
            {
                ProductCode = Guid.NewGuid().ToString(),
                VariantCode = Guid.NewGuid().ToString(),
                Quantity = 7

            };
        }

        public static string VariantStock()
        {
            var variant = Guid.NewGuid().ToString();
            
            return variant;

        }

        public static string ProductStock()
        {
            var product = Guid.NewGuid().ToString();

            return product;

        }
    }
}
