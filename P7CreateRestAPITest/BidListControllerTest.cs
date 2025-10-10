using Dot.Net.WebApi.Controllers;
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
    public class BidListControllerTest
    {
        private LocalDbContext context;
        private Mock<IBidListRepository> mockBidListRepository;

        public BidListControllerTest()
        {
            mockBidListRepository = new Mock<IBidListRepository>();
        }

        [Fact]
        public void GetBidListById()
        {
            int id = 1;
            mockBidListRepository.Setup(a => a.FindById(id)).ReturnsAsync(new BidList
            {
                BidListId = id,
                Account = "Account2",
                BidType = "Type2",
                BidQuantity = 200,
                AskQuantity = 180,
                Bid = 20.5,
                Ask = 21.0,
                Benchmark = "Benchmark2",
                BidListDate = DateTime.Now,
                Commentary = "Deuxième donnée",
                BidSecurity = "Sec2",
                BidStatus = "Closed",
                Trader = "Trader2",
                Book = "Book2",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal2",
                DealType = "TypeB",
                SourceListId = "SRC2",
                Side = "Sell"
            });
            var bidListController = new BidListController(mockBidListRepository.Object);
            var result = bidListController.BidList(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<BidList>(okResult.Value);
            Assert.Equal(id, returnValue.BidListId);
        }

        [Fact]
        public async Task CreateBidList()
        {
            BidList bidList = new BidList
            {
                BidListId = 1,
                Account = "Account5",
                BidType = "Type5",
                BidQuantity = 200,
                AskQuantity = 180,
                Bid = 20.5,
                Ask = 21.0,
                Benchmark = "Benchmark5",
                BidListDate = DateTime.Now,
                Commentary = "ceci est un test",
                BidSecurity = "Sec5",
                BidStatus = "Closed",
                Trader = "Trader5",
                Book = "Book5",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal5",
                DealType = "TypeB",
                SourceListId = "SRC5",
                Side = "Sell"
            };

            mockBidListRepository.Setup(r => r.Add(It.IsAny<BidList>()));
            mockBidListRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<BidList> { bidList });
            var bidListController = new BidListController(mockBidListRepository.Object);

            var result = await bidListController.Create(bidList);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<BidList>>(createdResult.Value);

            mockBidListRepository.Verify(r => r.Add(It.Is<BidList>(b => b.BidListId == 1)), Times.Once);
        }

        [Fact]
        public async Task DeleteABidList()
        {
            int id = 1;
            mockBidListRepository.Setup(a => a.FindById(id)).ReturnsAsync(new BidList
            {
                BidListId = id,
                Account = "Account2",
                BidType = "Type2",
                BidQuantity = 200,
                AskQuantity = 180,
                Bid = 20.5,
                Ask = 21.0,
                Benchmark = "Benchmark2",
                BidListDate = DateTime.Now,
                Commentary = "Deuxième donnée",
                BidSecurity = "Sec2",
                BidStatus = "Closed",
                Trader = "Trader2",
                Book = "Book2",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal2",
                DealType = "TypeB",
                SourceListId = "SRC2",
                Side = "Sell"
            });

            mockBidListRepository.Setup(r => r.Delete(It.IsAny<BidList>()));
            var bidListController = new BidListController(mockBidListRepository.Object);

            var result = await bidListController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockBidListRepository.Verify(r => r.Delete(It.Is<BidList>(b => b.BidListId == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateABidList()
        {
            int id = 1;
            BidList bidList = new BidList
            {
                BidListId = 1,
                Account = "Account",
                BidType = "Type",
                BidQuantity = 220,
                AskQuantity = 340,
                Bid = 24.5,
                Ask = 5.0,
                Benchmark = "Benchmark5",
                BidListDate = DateTime.Now,
                Commentary = "ceci est un test",
                BidSecurity = "Sec6",
                BidStatus = "Closed",
                Trader = "Trader5",
                Book = "Book5",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal5",
                DealType = "TypeB",
                SourceListId = "SRC5",
                Side = "Sell"
            };

            mockBidListRepository.Setup(r => r.Update(It.IsAny<BidList>()));
            mockBidListRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<BidList> { bidList });

            var bidListController = new BidListController(mockBidListRepository.Object);

            var result = await bidListController.Update(id, bidList);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<BidList>>(createdResult.Value);

            mockBidListRepository.Verify(r => r.Update(It.Is<BidList>(b => b.BidListId == 1)), Times.Once);
        }
    }
}