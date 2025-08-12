using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        public LocalDbContext DbContext { get; }

        public TradeRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Trade FindByTrader(string trader)
        {
            Trade trade = DbContext.Trades.Where(trade => trade.Trader == trader).FirstOrDefault();
            if (trade == null)
            {
                return null;
            }
            return trade;
        }

        public async Task<List<Trade>> FindAll()
        {
            return await DbContext.Trades.ToListAsync();
        }

        public void Add(Trade trade)
        {
            DbContext.Trades.Add(trade);
            DbContext.SaveChanges();
        }

        public void Update(Trade trade)
        {
            DbContext.Trades.Update(trade);
            DbContext.SaveChanges();
        }

        public void Delete(Trade trade)
        {
            DbContext.Trades.Remove(trade);
            DbContext.SaveChanges();
        }

        public async Task<Trade> FindById(int id)
        {
            Trade trade = await DbContext.Trades.FirstOrDefaultAsync(t => t.TradeId == id);
            if (trade == null) {
                return null;
            }
            return trade;
        }
    }
}