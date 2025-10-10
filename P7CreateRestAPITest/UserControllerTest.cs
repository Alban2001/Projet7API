using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Repositories;

namespace P7CreateRestAPITest
{
    public class UserControllerTest
    {
        private LocalDbContext context;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<UserManager<User>> mockUserRepositoryManager;

        public UserControllerTest()
        {
            mockUserRepository = new Mock<IUserRepository>();
            var store = new Mock<IUserStore<User>>();
            mockUserRepositoryManager = new Mock<UserManager<User>>(
                store.Object, null, null, null, null, null, null, null, null);
        }

        [Fact]
        public void GetUserById()
        {
            string id = "1";
            User user = new User { Id = id, UserName = "avoiriot" };
            mockUserRepository.Setup(r => r.FindById(id))
                    .ReturnsAsync(user);

            var UserController = new UserController(mockUserRepository.Object, mockUserRepositoryManager.Object); 
            var result = UserController.User(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<User>(okResult.Value);
            Assert.Equal(id, returnValue.Id);
        }

        [Fact]
        public async Task CreateUser()
        {
            User user = new User { UserName = "avoiriot", Fullname = "Alban VOIRIOT", Email = "alban.voiriot@gmail.com", Password = "Password1234" };

            mockUserRepositoryManager.Setup(um => um.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Success);
            mockUserRepositoryManager.Setup(um => um.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Success);

            mockUserRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<User> { user });
            var UserController = new UserController(mockUserRepository.Object, mockUserRepositoryManager.Object);

            var result = await UserController.Create(user);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<User>>(createdResult.Value);

            mockUserRepositoryManager.Verify(um => um.CreateAsync(It.Is<User>(u => u.UserName == "avoiriot"), "Password1234"), Times.Once);
            mockUserRepositoryManager.Verify(um => um.AddToRoleAsync(It.Is<User>(u => u.UserName == "avoiriot"), "USER"), Times.Once);
        }

        [Fact]
        public async Task DeleteAUser()
        {
            string id = "1";
            User user = new User { Id = id, UserName = "avoiriot" };
            mockUserRepository.Setup(r => r.FindById(id))
                    .ReturnsAsync(user);

            mockUserRepositoryManager.Setup(r => r.DeleteAsync(It.IsAny<User>()));
            var UserController = new UserController(mockUserRepository.Object, mockUserRepositoryManager.Object);

            var result = await UserController.Delete(id);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

            mockUserRepositoryManager.Verify(r => r.DeleteAsync(It.Is<User>(b => b.Id == "1")), Times.Once);
        }

        [Fact]
        public async Task UpdateATrade()
        {
            string id = "1";
            User user = new User { Id = id, UserName = "avoiriot", Fullname = "Alban VOIRIOT", Email = "alban.voiriot@gmail.com", Password = "Password1234" };

            mockUserRepositoryManager.Setup(r => r.UpdateAsync(It.IsAny<User>()));
            mockUserRepository.Setup(r => r.FindAll())
                .ReturnsAsync(new List<User> { user });

            var UserController = new UserController(mockUserRepository.Object, mockUserRepositoryManager.Object);

            var result = await UserController.Update(id, user);

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.IsAssignableFrom<IEnumerable<User>>(createdResult.Value);

            mockUserRepositoryManager.Verify(um => um.UpdateAsync(It.Is<User>(u => u.UserName == "avoiriot")), Times.Once);
        }
    }
}