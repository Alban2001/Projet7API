using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRatingRepository
    {
        Task<List<Rating>> FindAll();
        void Add(Rating rating);
        void Update(Rating rating);
        void Delete(Rating rating);
        Task<Rating> FindById(int id);
    }
}
