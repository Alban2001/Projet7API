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
    public class RuleNameControllerTest
    {
        private LocalDbContext context;
        private Mock<IRuleNameRepository> mockRuleNameRepository;

        public RuleNameControllerTest()
        {
            mockRuleNameRepository = new Mock<IRuleNameRepository>();
        }

        [Fact]
        public void GetRuleNameById()
        {
            int id = 1;
            mockRuleNameRepository.Setup(a => a.FindById(id)).ReturnsAsync(new RuleName
            {
                Id = id,
                Name = "HighValueTradeRule",
                Description = "Règle pour détecter les transactions de grande valeur",
                Json = "{ minValue: 100000 }",
                Template = "Si transaction > {minValue}, alerte",
                SqlStr = "SELECT * FROM Trades WHERE Amount > 100000",
                SqlPart = "Amount > 100000"
            });
            var RuleNameController = new RuleNameController(mockRuleNameRepository.Object);
            var result = RuleNameController.RuleName(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<RuleName>(okResult.Value);
            Assert.Equal(id, returnValue.Id);
        }

        [Fact]
        public async Task CreateRuleName()
        {
            RuleName ruleName = new RuleName
            {
                Id = 1,
                Name = "HighValueTradeRule",
                Description = "Règle pour détecter les transactions de grande valeur",
                Json = "{ minValue: 100000 }",
                Template = "Si transaction > {minValue}, alerte",
                SqlStr = "SELECT * FROM Trades WHERE Amount > 100000",
                SqlPart = "Amount > 100000"
            };

            mockRuleNameRepository.Setup(r => r.Add(It.IsAny<RuleName>()));
            mockRuleNameRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<RuleName> { ruleName });
            var RuleNameController = new RuleNameController(mockRuleNameRepository.Object);

            var result = await RuleNameController.Create(ruleName);

            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RuleName>>(createdResult.Value);

            mockRuleNameRepository.Verify(r => r.Add(It.Is<RuleName>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task DeleteARuleName()
        {
            int id = 1;
            mockRuleNameRepository.Setup(a => a.FindById(id)).ReturnsAsync(new RuleName
            {
                Id = id,
                Name = "HighValueTradeRule",
                Description = "Règle pour détecter les transactions de grande valeur",
                Json = "{ minValue: 100000 }",
                Template = "Si transaction > {minValue}, alerte",
                SqlStr = "SELECT * FROM Trades WHERE Amount > 100000",
                SqlPart = "Amount > 100000"
            });

            mockRuleNameRepository.Setup(r => r.Delete(It.IsAny<RuleName>()));
            var RuleNameController = new RuleNameController(mockRuleNameRepository.Object);

            var result = await RuleNameController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockRuleNameRepository.Verify(r => r.Delete(It.Is<RuleName>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateARuleName()
        {
            int id = 1;
            RuleName ruleName = new RuleName
            {
                Id = 1,
                Name = "HighValueTradeRule",
                Description = "Règle pour détecter les transactions de grande valeur",
                Json = "{ minValue: 100000 }",
                Template = "Si transaction > {minValue}, alerte",
                SqlStr = "SELECT * FROM Trades WHERE Amount > 100000",
                SqlPart = "Amount > 100000"
            };

            mockRuleNameRepository.Setup(r => r.Update(It.IsAny<RuleName>()));
            mockRuleNameRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<RuleName> { ruleName });

            var RuleNameController = new RuleNameController(mockRuleNameRepository.Object);

            var result = await RuleNameController.Update(id, ruleName);

            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RuleName>>(createdResult.Value);

            mockRuleNameRepository.Verify(r => r.Update(It.Is<RuleName>(b => b.Id == 1)), Times.Once);
        }
    }
}