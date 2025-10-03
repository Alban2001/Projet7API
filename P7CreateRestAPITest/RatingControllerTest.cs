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
    public class RatingControllerTest
    {
        private LocalDbContext context;
        private Mock<IRatingRepository> mockRatingRepository;

        public RatingControllerTest()
        {
            mockRatingRepository = new Mock<IRatingRepository>();
        }

        [Fact]
        public void GetRatingById()
        {
            int id = 1;
            mockRatingRepository.Setup(a => a.FindById(id)).ReturnsAsync(new Rating
            {
                Id = id,
                MoodysRating = "Aa2",
                SandPRating = "AA",
                FitchRating = "AA-",
                OrderNumber = 1
            });
            var RatingController = new RatingController(mockRatingRepository.Object);
            var result = RatingController.Rating(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Rating>(okResult.Value);
            Assert.Equal(id, returnValue.Id);
        }

        [Fact]
        public async Task CreateRating()
        {
            Rating rating = new Rating
            {
                Id = 1,
                MoodysRating = "Aa2",
                SandPRating = "AA",
                FitchRating = "AA-",
                OrderNumber = 1
            };

            mockRatingRepository.Setup(r => r.Add(It.IsAny<Rating>()));
            mockRatingRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<Rating> { rating });
            var RatingController = new RatingController(mockRatingRepository.Object);

            var result = await RatingController.Create(rating);

            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Rating>>(createdResult.Value);

            mockRatingRepository.Verify(r => r.Add(It.Is<Rating>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task DeleteARating()
        {
            int id = 1;
            mockRatingRepository.Setup(a => a.FindById(id)).ReturnsAsync(new Rating
            {
                Id = id,
                MoodysRating = "Aa2",
                SandPRating = "AA",
                FitchRating = "AA-",
                OrderNumber = 1
            });

            mockRatingRepository.Setup(r => r.Delete(It.IsAny<Rating>()));
            var RatingController = new RatingController(mockRatingRepository.Object);

            var result = await RatingController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockRatingRepository.Verify(r => r.Delete(It.Is<Rating>(b => b.Id == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateARating()
        {
            int id = 1;
            Rating rating = new Rating
            {
                Id = 1,
                MoodysRating = "Aa2",
                SandPRating = "AA",
                FitchRating = "AA-",
                OrderNumber = 1
            };

            mockRatingRepository.Setup(r => r.Update(It.IsAny<Rating>()));
            mockRatingRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<Rating> { rating });

            var RatingController = new RatingController(mockRatingRepository.Object);

            var result = await RatingController.Update(id, rating);

            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Rating>>(createdResult.Value);

            mockRatingRepository.Verify(r => r.Update(It.Is<Rating>(b => b.Id == 1)), Times.Once);
        }
    }
}