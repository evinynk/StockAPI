using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Stock.Business.Abstract;
using Stock.Business.Concrete;
using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private IProductStockService _productStockService;
        public StocksController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(_productStockService.GetAllProductStocks());
        //}

        /// <summary>
        /// Get All Stocks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stocks = await _productStockService.GetAllProductStocks();
            if(stocks.Count == 0)
            {
                return NoContent();
            }
            return Ok(stocks);
        }

        /// <summary>
        /// Get Stock By Product
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productCode}/[action]")]
        public async Task<IActionResult> Product(string productCode)
        {
            var code = await _productStockService.GetProductStockByProductCode(productCode);
            if(code != null)
            {
                return Ok(code);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Stock By Variant
        /// </summary>
        /// <param name="variantCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{variantCode}/[action]")]
        public async Task<IActionResult> Variant(string variantCode)
        {
            var code =await _productStockService.GetProductStockByVariantCode(variantCode);
            if (code != null)
            {
                return Ok(code);
            }
            return NotFound();
        }

        /// <summary>
        /// Create a Stock
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] ProductStock productStock)
        {
            var createdStock = await _productStockService.CreateProductStock(productStock);
            //return Ok(createdStock);    
            return CreatedAtAction("Get", new { id = productStock.Id }, createdStock);
            
        }


 

        //[HttpPost]
        //public async Task<IActionResult>  Post(ProductStock productStock)
        //{
        //    var stock = new ProductStock()
        //    {
        //        Id = Guid.NewGuid(),
        //        VariantCode = productStock.VariantCode,
        //        ProductCode = productStock.ProductCode,
        //        Quantity = productStock.Quantity

        //    };
        //    await _productStockService.CreateProductStock(stock);
        //    return Ok(stock);


        //}

        //[HttpGet]
        //public List<ProductStock> Get()
        //{
        //    return _productStockService.GetAllProductStocks();
        //}


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_productStockService.GetAllProductStocks());
        //}



        //[HttpGet("{id}")]
        //public ProductStock Get(int id)
        //{
        //    return _productStockService.GetProductStockById(id);
        //}



        //[HttpGet("{productCode}")]
        //public ProductStock Get(string productCode)
        //{
        //    return _productStockService.GetProductStockByProductCode(productCode);
        //}


        //[HttpGet("{variantCode}")]
        //public ProductStock Get(string variantCode)
        //{
        //    return _productStockService.GetProductStockByVariantCode(variantCode);
        //}


        //[HttpPost]
        //public ProductStock Post([FromBody]ProductStock productStock)
        //{
        //    return _productStockService.CreateProductStock(productStock);
        //}


        //[HttpPut]
        //public ProductStock Put([FromBody] ProductStock productStock)
        //{
        //    return _productStockService.UpdateProductStock(productStock);
        //}


        //[HttpGet("{id}")]
        //public void Delete( int id)
        //{
        //    _productStockService.DeleteProductStock(id);
        //}
    }
}
