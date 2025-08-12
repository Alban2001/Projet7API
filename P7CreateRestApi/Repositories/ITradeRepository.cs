using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ITradeRepository
    {
        Trade FindByTrader(string trader);
        Task<List<Trade>> FindAll();
        void Add(Trade trade);
        void Update(Trade trade);
        void Delete(Trade trade);
        Task<Trade> FindById(int id);
    }
}
