using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using P7CreateRestApi.Repositories;

namespace P7CreateRestAPITest
{
    public class TradeControllerTest
    {
        private LocalDbContext context;
        private Mock<ITradeRepository> mockTradeRepository;

        public TradeControllerTest()
        {
            mockTradeRepository = new Mock<ITradeRepository>();
        }

        [Fact]
        public void GetTradeById()
        {
            int id = 1;
            mockTradeRepository.Setup(a => a.FindById(id)).ReturnsAsync(new Trade
            {
                TradeId = id,
                Account = "Account1",
                AccountType = "TypeA",
                BuyQuantity = 1000,
                SellQuantity = 0,
                BuyPrice = 50.5,
                SellPrice = null,
                TradeDate = DateTime.Now.AddDays(-5),
                TradeSecurity = "SEC123",
                TradeStatus = "Open",
                Trader = "Trader1",
                Benchmark = "Benchmark1",
                Book = "BookA",
                CreationName = "Admin",
                CreationDate = DateTime.Now.AddDays(-5),
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "DealAlpha",
                DealType = "Type1",
                SourceListId = "SRC001",
                Side = "Buy"
            });
            var TradeController = new TradeController(mockTradeRepository.Object);
            var result = TradeController.Trade(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Trade>(okResult.Value);
            Assert.Equal(id, returnValue.TradeId);
        }

        [Fact]
        public async Task CreateTrade()
        {
            Trade trade = new Trade
            {
                TradeId = 1,
                Account = "Account1",
                AccountType = "TypeA",
                BuyQuantity = 1000,
                SellQuantity = 0,
                BuyPrice = 50.5,
                SellPrice = null,
                TradeDate = DateTime.Now.AddDays(-5),
                TradeSecurity = "SEC123",
                TradeStatus = "Open",
                Trader = "Trader1",
                Benchmark = "Benchmark1",
                Book = "BookA",
                CreationName = "Admin",
                CreationDate = DateTime.Now.AddDays(-5),
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "DealAlpha",
                DealType = "Type1",
                SourceListId = "SRC001",
                Side = "Buy"
            };

            mockTradeRepository.Setup(r => r.Add(It.IsAny<Trade>()));
            mockTradeRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<Trade> { trade });
            var TradeController = new TradeController(mockTradeRepository.Object);

            var result = await TradeController.Create(trade);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Trade>>(createdResult.Value);

            mockTradeRepository.Verify(r => r.Add(It.Is<Trade>(b => b.TradeId == 1)), Times.Once);
        }

        [Fact]
        public async Task DeleteATrade()
        {
            int id = 1;
            mockTradeRepository.Setup(a => a.FindById(id)).ReturnsAsync(new Trade
            {
                TradeId = id,
                Account = "Account1",
                AccountType = "TypeA",
                BuyQuantity = 1000,
                SellQuantity = 0,
                BuyPrice = 50.5,
                SellPrice = null,
                TradeDate = DateTime.Now.AddDays(-5),
                TradeSecurity = "SEC123",
                TradeStatus = "Open",
                Trader = "Trader1",
                Benchmark = "Benchmark1",
                Book = "BookA",
                CreationName = "Admin",
                CreationDate = DateTime.Now.AddDays(-5),
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "DealAlpha",
                DealType = "Type1",
                SourceListId = "SRC001",
                Side = "Buy"
            });

            mockTradeRepository.Setup(r => r.Delete(It.IsAny<Trade>()));
            var TradeController = new TradeController(mockTradeRepository.Object);

            var result = await TradeController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockTradeRepository.Verify(r => r.Delete(It.Is<Trade>(b => b.TradeId == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateATrade()
        {
            int id = 1;
            Trade trade = new Trade
            {
                TradeId = 1,
                Account = "Account1",
                AccountType = "TypeA",
                BuyQuantity = 1000,
                SellQuantity = 0,
                BuyPrice = 50.5,
                SellPrice = null,
                TradeDate = DateTime.Now.AddDays(-5),
                TradeSecurity = "SEC123",
                TradeStatus = "Open",
                Trader = "Trader1",
                Benchmark = "Benchmark1",
                Book = "BookA",
                CreationName = "Admin",
                CreationDate = DateTime.Now.AddDays(-5),
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "DealAlpha",
                DealType = "Type1",
                SourceListId = "SRC001",
                Side = "Buy"
            };

            mockTradeRepository.Setup(r => r.Update(It.IsAny<Trade>()));
            mockTradeRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<Trade> { trade });

            var TradeController = new TradeController(mockTradeRepository.Object);

            var result = await TradeController.Update(id, trade);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Trade>>(createdResult.Value);

            mockTradeRepository.Verify(r => r.Update(It.Is<Trade>(b => b.TradeId == 1)), Times.Once);
        }
    }
}