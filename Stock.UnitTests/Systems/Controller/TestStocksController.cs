using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Stock.API.Controllers;
using Stock.Business.Abstract;
using Stock.UnitTests.MockData;

namespace Stock.UnitTests.Systems.Controller
{
    public class TestStocksController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange

            var stockService = new Mock<IProductStockService>();
            stockService.Setup(_ => _.GetAllProductStocks()).ReturnsAsync(StockMockData.GetStocks());    
            var sut = new StocksController(stockService.Object); 

            //Act
            var result = await sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_ShouldReturnStatusCode204()
        {
            //Arrange
            var stockService = new Mock<IProductStockService>();
            stockService.Setup(_ => _.GetAllProductStocks()).ReturnsAsync(StockMockData.EmptyStocks());
            var sut = new StocksController(stockService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task CreateStock_ShouldCallToDoCreateStockOnce()
        {
            //Arrange
            var stockService = new Mock<IProductStockService>();
            var newStock = StockMockData.CreateProductStock();
            var sut = new StocksController(stockService.Object);

            //Act
            var result = await sut.CreateStock(newStock);

            //Assert
            stockService.Verify(_ => _.CreateProductStock(newStock), Times.Exactly(1));



        }

        [Fact]
        public async Task Variant_ShouldCallToDoVariant()
        {
            //Arrange
            var stockService = new Mock<IProductStockService>();
            var variant = StockMockData.VariantStock();
            var sut = new StocksController(stockService.Object);

            //Act
            var result = await sut.Variant(variant);

            //Assert
            stockService.Verify(_ => _.GetProductStockByVariantCode(variant), Times.Exactly(1));
        }
        [Fact]
        public async Task Product_ShouldCallToDoProduct()
        {
            //Arrange
            var stockService = new Mock<IProductStockService>();
            var product = StockMockData.ProductStock();
            var sut = new StocksController(stockService.Object);

            //Act
            var result = await sut.Product(product);

            //Assert
            stockService.Verify(_ => _.GetProductStockByProductCode(product), Times.Exactly(1));
        }
    }
}