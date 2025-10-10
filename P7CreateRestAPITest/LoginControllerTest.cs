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
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;
using System.Security.Claims;

namespace P7CreateRestAPITest
{
    public class LoginControllerTest
    {
        private LocalDbContext context;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<IAuthenticationService> mockAS;
        private Mock<IConfiguration> mockConfig;
        private Mock<UserManager<User>> mockUserRepositoryManager;
        private Mock<SignInManager<User>> mockSignManager;

        public LoginControllerTest()
        {
            mockUserRepository = new Mock<IUserRepository>();
            var store = new Mock<IUserStore<User>>();
            mockUserRepositoryManager = new Mock<UserManager<User>>(
                store.Object, null, null, null, null, null, null, null, null);
           
            var contextAccessor = new Mock<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<User>>();
            mockSignManager = new Mock<SignInManager<User>>(
                mockUserRepositoryManager.Object,
                contextAccessor.Object,
                claimsFactory.Object,
                null, null, null, null);
            mockAS = new Mock<IAuthenticationService>();
        }

        [Fact]
        public void LoginSuccess()
        {
            User model = new User { UserName = "avoiriot", Password = "Password1234"};
            mockUserRepository.Setup(r => r.FindByUserName("avoiriot"))
                    .Returns(model);
            mockSignManager.Setup(r => r.CheckPasswordSignInAsync(It.IsAny<User>(), "Password1234", false))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            mockUserRepositoryManager.Setup(u => u.GetRolesAsync(model))
                       .ReturnsAsync(new List<string> { "USER" });

            mockAS.Setup(a => a.GenerateToken("MaClé", It.IsAny<List<Claim>>()))
                       .Returns("token");

            var inMemorySettings = new Dictionary<string, string> { { "Jwt:Key", "MaClé" } };
            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            var LoginController = new LoginController(mockAS.Object, config, mockSignManager.Object, mockUserRepositoryManager.Object, mockUserRepository.Object);
            LoginModel model2 = new LoginModel { UserName = "avoiriot", Password = "Password1234" };

            var result = LoginController.Login(model2);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var token = Assert.IsType<string>(okResult.Value);
            Assert.Equal("token", token);
        }

        [Fact]
        public void LoginNotFoundUser()
        {
            mockUserRepository.Setup(r => r.FindByUserName("avoiriot"))
                    .Returns((User)null);

            var inMemorySettings = new Dictionary<string, string> { { "Jwt:Key", "MaClé" } };
            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            var LoginController = new LoginController(mockAS.Object, config, mockSignManager.Object, mockUserRepositoryManager.Object, mockUserRepository.Object);
            LoginModel model2 = new LoginModel { UserName = "avoiriot", Password = "Password1234" };

            var result = LoginController.Login(model2);

            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("Identifiant et mot de passe incorrect !", unauthorizedResult.Value);
        }

        [Fact]
        public void LoginInvalidPassword()
        {
            User model = new User { UserName = "avoiriot", Password = "Password1234" };
            mockUserRepository.Setup(r => r.FindByUserName("avoiriot"))
                    .Returns(model);
            mockSignManager.Setup(r => r.CheckPasswordSignInAsync(It.IsAny<User>(), "Password1234", false))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            var inMemorySettings = new Dictionary<string, string> { { "Jwt:Key", "MaClé" } };
            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            var LoginController = new LoginController(mockAS.Object, config, mockSignManager.Object, mockUserRepositoryManager.Object, mockUserRepository.Object);
            LoginModel model2 = new LoginModel { UserName = "avoiriot", Password = "Password1234" };

            var result = LoginController.Login(model2);

            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("Identifiant et mot de passe incorrect !", unauthorizedResult.Value);
        }

        [Fact]
        public void LoginNotFoundRoles()
        {
            User model = new User { UserName = "avoiriot", Password = "Password1234" };
            mockUserRepository.Setup(r => r.FindByUserName("avoiriot"))
                    .Returns(model);
            mockSignManager.Setup(r => r.CheckPasswordSignInAsync(It.IsAny<User>(), "Password1234", false))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            mockUserRepositoryManager.Setup(u => u.GetRolesAsync(model))
                       .ReturnsAsync([]);

            var inMemorySettings = new Dictionary<string, string> { { "Jwt:Key", "MaClé" } };
            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            var LoginController = new LoginController(mockAS.Object, config, mockSignManager.Object, mockUserRepositoryManager.Object, mockUserRepository.Object);
            LoginModel model2 = new LoginModel { UserName = "avoiriot", Password = "Password1234" };

            var result = LoginController.Login(model2);

            Assert.IsType<UnauthorizedResult>(result.Result);
        }
    }
}