using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IBidListRepository
    {
        BidList FindByAccount(string Account);
        Task<List<BidList>> FindAll();
        void Add(BidList bidList);
        void Update(BidList bidList);
        void Delete(BidList bidList);
        Task<BidList> FindById(int id);
    }
}
