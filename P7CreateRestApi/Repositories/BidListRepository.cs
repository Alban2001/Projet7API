using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class BidListRepository
    {
        public LocalDbContext DbContext { get; }

        public BidListRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BidList FindByAccount(string Account)
        {
            BidList bidList = DbContext.Bids.Where(bid => bid.Account == Account).FirstOrDefault();
            if (bidList == null)
            {
                return null;
            }
            return bidList;
        }

        public async Task<List<BidList>> FindAll()
        {
            return await DbContext.Bids.ToListAsync();
        }

        public void Add(BidList bidList)
        {
            DbContext.Bids.Add(bidList);
        }

        public void Update(BidList bidList)
        {
            DbContext.Bids.Update(bidList);
        }

        public void Delete(BidList bidList)
        {
            DbContext.Bids.Remove(bidList);
        }

        public BidList FindById(int id)
        {
            BidList unBidList = DbContext.Bids.Find(id);
            if (unBidList == null) {
                return null;
            }
            return unBidList;
        }
    }
}