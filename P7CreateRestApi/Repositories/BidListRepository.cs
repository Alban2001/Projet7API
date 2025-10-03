using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class BidListRepository : IBidListRepository
    {
        public LocalDbContext DbContext { set; get; }

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
            DbContext.SaveChanges();
        }

        public void Update(BidList bidList)
        {
            DbContext.Bids.Update(bidList);
            DbContext.SaveChanges();
        }

        public void Delete(BidList bidList)
        {
            DbContext.Bids.Remove(bidList);
            DbContext.SaveChanges();
        }

        public async Task<BidList> FindById(int id)
        {
            BidList unBidList = await DbContext.Bids.FirstOrDefaultAsync(bd => bd.BidListId == id);
            if (unBidList == null) {
                return null;
            }
            return unBidList;
        }
    }
}