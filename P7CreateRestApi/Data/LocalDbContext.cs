using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Repositories;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : DbContext
    {
        private DataRepository _dataRepository;

        public LocalDbContext(DbContextOptions<LocalDbContext> options, DataRepository dataRepository) : base(options)
        {
            _dataRepository = dataRepository;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<BidList> Bids { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RuleName> RuleNames { get; set; }
        public DbSet<User> Users { get; set; }

        public static void Initialize(LocalDbContext context)
        {   
            // Si la base contient déjà des données, on ne fait rien
            if (!context.Bids.Any())
                context._dataRepository.InitializeBidList(context);

            if (!context.CurvePoints.Any())
                context._dataRepository.InitializeCurvePoint(context);

            if (!context.Ratings.Any())
                context._dataRepository.InitializeRating(context);

            if (!context.RuleNames.Any())
                context._dataRepository.InitializeRuleName(context);

            if (!context.Trades.Any())
                context._dataRepository.InitializeTrade(context);

            if (!context.Users.Any())
                context._dataRepository.InitializeUser(context);
        }

    }
}