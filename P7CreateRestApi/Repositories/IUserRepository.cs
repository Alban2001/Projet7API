using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IUserRepository
    {
        User FindByUserName(string userName);
        Task<List<User>> FindAll();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        Task<User> FindById(string id);
    }
}
