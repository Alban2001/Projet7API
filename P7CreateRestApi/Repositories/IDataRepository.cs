using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IDataRepository
    {
        void InitializeBidList(LocalDbContext context);
        void InitializeCurvePoint(LocalDbContext context);
        void InitializeRating(LocalDbContext context);
        void InitializeRuleName(LocalDbContext context);
        void InitializeTrade(LocalDbContext context);
        void InitializeUser(LocalDbContext context);
    }
}
