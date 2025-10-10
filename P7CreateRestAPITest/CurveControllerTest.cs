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
    public class CurveControllerTest
    {
        private LocalDbContext context;
        private Mock<ICurvePointRepository> mockCurvePointRepository;

        public CurveControllerTest()
        {
            mockCurvePointRepository = new Mock<ICurvePointRepository>();
        }

        [Fact]
        public void GetCurvePointById()
        {
            int id = 1;
            mockCurvePointRepository.Setup(a => a.FindById(id)).ReturnsAsync(new CurvePoint
            {
                Id = id,
                CurveId = 1,
                AsOfDate = DateTime.Now.AddDays(-10),
                Term = 1.5,
                CurvePointValue = 10.25,
                CreationDate = DateTime.Now.AddDays(-10)
            });
            var curveController = new CurveController(mockCurvePointRepository.Object);
            var result = curveController.Curve(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<CurvePoint>(okResult.Value);
            Assert.Equal(id, returnValue.Id);
        }

        [Fact]
        public async Task CreateCurvePoint()
        {
            CurvePoint curvePoint = new CurvePoint
            {
                Id = 1,
                CurveId = 1,
                AsOfDate = DateTime.Now.AddDays(-10),
                Term = 1.5,
                CurvePointValue = 10.25,
                CreationDate = DateTime.Now.AddDays(-10)
            };

            mockCurvePointRepository.Setup(r => r.Add(It.IsAny<CurvePoint>()));
            mockCurvePointRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<CurvePoint> { curvePoint });
            var curveController = new CurveController(mockCurvePointRepository.Object);

            var result = await curveController.Create(curvePoint);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<CurvePoint>>(createdResult.Value);

            mockCurvePointRepository.Verify(r => r.Add(It.Is<CurvePoint>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task DeleteACurvePoint()
        {
            int id = 1;
            mockCurvePointRepository.Setup(a => a.FindById(id)).ReturnsAsync(new CurvePoint
            {
                Id = id,
                CurveId = 1,
                AsOfDate = DateTime.Now.AddDays(-10),
                Term = 1.5,
                CurvePointValue = 10.25,
                CreationDate = DateTime.Now.AddDays(-10)
            });

            mockCurvePointRepository.Setup(r => r.Delete(It.IsAny<CurvePoint>()));
            var CurveController = new CurveController(mockCurvePointRepository.Object);

            var result = await CurveController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockCurvePointRepository.Verify(r => r.Delete(It.Is<CurvePoint>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateACurvePoint()
        {
            int id = 1;
            CurvePoint curvePoint = new CurvePoint
            {
                Id = 1,
                CurveId = 1,
                AsOfDate = DateTime.Now.AddDays(-10),
                Term = 1.5,
                CurvePointValue = 10.25,
                CreationDate = DateTime.Now.AddDays(-10)
            };

            mockCurvePointRepository.Setup(r => r.Update(It.IsAny<CurvePoint>()));
            mockCurvePointRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<CurvePoint> { curvePoint });

            var curveController = new CurveController(mockCurvePointRepository.Object);

            var result = await curveController.Update(id, curvePoint);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<CurvePoint>>(createdResult.Value);

            mockCurvePointRepository.Verify(r => r.Update(It.Is<CurvePoint>(b => b.Id == 1)), Times.Once);
        }
    }
}