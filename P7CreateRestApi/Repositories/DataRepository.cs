using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class DataRepository : IDataRepository
    {
        public void InitializeBidList(LocalDbContext context)
        {
            var bidLists = new List<BidList>
        {
            new BidList
            {
                Account = "Account1",
                BidType = "Type1",
                BidQuantity = 100,
                AskQuantity = 90,
                Bid = 10.5,
                Ask = 11.0,
                Benchmark = "Benchmark1",
                BidListDate = DateTime.Now,
                Commentary = "Première donnée",
                BidSecurity = "Sec1",
                BidStatus = "Open",
                Trader = "Trader1",
                Book = "Book1",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal1",
                DealType = "TypeA",
                SourceListId = "SRC1",
                Side = "Buy"
            },
            new BidList
            {
                Account = "Account2",
                BidType = "Type2",
                BidQuantity = 200,
                AskQuantity = 180,
                Bid = 20.5,
                Ask = 21.0,
                Benchmark = "Benchmark2",
                BidListDate = DateTime.Now,
                Commentary = "Deuxième donnée",
                BidSecurity = "Sec2",
                BidStatus = "Closed",
                Trader = "Trader2",
                Book = "Book2",
                CreationName = "Admin",
                CreationDate = DateTime.Now,
                RevisionName = "Admin",
                RevisionDate = DateTime.Now,
                DealName = "Deal2",
                DealType = "TypeB",
                SourceListId = "SRC2",
                Side = "Sell"
            }
        };

            context.Bids.AddRange(bidLists);
            context.SaveChanges();
        }

        public void InitializeCurvePoint(LocalDbContext context)
        {
            var curvePoints = new List<CurvePoint>
            {
                new CurvePoint
                {
                    CurveId = 1,
                    AsOfDate = DateTime.Now.AddDays(-10),
                    Term = 1.5,
                    CurvePointValue = 10.25,
                    CreationDate = DateTime.Now.AddDays(-10)
                },
                new CurvePoint
                {
                    CurveId = 2,
                    AsOfDate = DateTime.Now.AddDays(-5),
                    Term = 2.0,
                    CurvePointValue = 15.75,
                    CreationDate = DateTime.Now.AddDays(-5)
                },
                new CurvePoint
                {
                    CurveId = 3,
                    AsOfDate = DateTime.Now,
                    Term = 3.0,
                    CurvePointValue = 20.00,
                    CreationDate = DateTime.Now
                }
            };

            context.CurvePoints.AddRange(curvePoints);
            context.SaveChanges();
        }

        public void InitializeRating(LocalDbContext context)
        {
            var ratings = new List<Rating>
            {
                new Rating
                {
                    MoodysRating = "Aa2",
                    SandPRating = "AA",
                    FitchRating = "AA-",
                    OrderNumber = 1
                },
                new Rating
                {
                    MoodysRating = "Baa1",
                    SandPRating = "BBB+",
                    FitchRating = "BBB",
                    OrderNumber = 2
                },
                new Rating
                {
                    MoodysRating = "Caa1",
                    SandPRating = "CCC+",
                    FitchRating = "CCC",
                    OrderNumber = 3
                }
            };

            context.Ratings.AddRange(ratings);
            context.SaveChanges();
        }

        public void InitializeRuleName(LocalDbContext context)
        {
            var rules = new List<RuleName>
            {
                new RuleName
                {
                    Name = "HighValueTradeRule",
                    Description = "Règle pour détecter les transactions de grande valeur",
                    Json = "{ minValue: 100000 }",
                    Template = "Si transaction > {minValue}, alerte",
                    SqlStr = "SELECT * FROM Trades WHERE Amount > 100000",
                    SqlPart = "Amount > 100000"
                },
                new RuleName
                {
                    Name = "LowLiquidityRule",
                    Description = "Règle pour repérer les actifs peu liquides",
                    Json = "{ daysWithoutTrade: 30 }",
                    Template = "Si aucun trade depuis {daysWithoutTrade} jours, alerte",
                    SqlStr = "SELECT * FROM Assets WHERE DaysWithoutTrade > 30",
                    SqlPart = "DaysWithoutTrade > 30"
                },
                new RuleName
                {
                    Name = "CurrencyMismatchRule",
                    Description = "Règle pour détecter les devises incohérentes",
                    Json = "{ \"baseCurrency\": \"USD\" }",
                    Template = "Si devise ≠ {baseCurrency}, alerte",
                    SqlStr = "SELECT * FROM Trades WHERE Currency <> 'USD'",
                    SqlPart = "Currency <> 'USD'"
                }
            };

            context.RuleNames.AddRange(rules);
            context.SaveChanges();
        }

        public void InitializeTrade(LocalDbContext context)
        {
            var trades = new List<Trade>
            {
                new Trade
                {
                    Account = "Account1",
                    AccountType = "TypeA",
                    BuyQuantity = 1000,
                    SellQuantity = 0,
                    BuyPrice = 50.5,
                    SellPrice = null,
                    TradeDate = DateTime.Now.AddDays(-5),
                    TradeSecurity = "SEC123",
                    TradeStatus = "Open",
                    Trader = "Trader1",
                    Benchmark = "Benchmark1",
                    Book = "BookA",
                    CreationName = "Admin",
                    CreationDate = DateTime.Now.AddDays(-5),
                    RevisionName = "Admin",
                    RevisionDate = DateTime.Now,
                    DealName = "DealAlpha",
                    DealType = "Type1",
                    SourceListId = "SRC001",
                    Side = "Buy"
                },
                new Trade
                {
                    Account = "Account2",
                    AccountType = "TypeB",
                    BuyQuantity = null,
                    SellQuantity = 500,
                    BuyPrice = null,
                    SellPrice = 75.25,
                    TradeDate = DateTime.Now.AddDays(-2),
                    TradeSecurity = "SEC456",
                    TradeStatus = "Closed",
                    Trader = "Trader2",
                    Benchmark = "Benchmark2",
                    Book = "BookB",
                    CreationName = "Admin",
                    CreationDate = DateTime.Now.AddDays(-2),
                    RevisionName = "Admin",
                    RevisionDate = DateTime.Now,
                    DealName = "DealBeta",
                    DealType = "Type2",
                    SourceListId = "SRC002",
                    Side = "Sell"
                },
                new Trade
                {
                    Account = "Account3",
                    AccountType = "TypeC",
                    BuyQuantity = 200,
                    SellQuantity = 150,
                    BuyPrice = 100.0,
                    SellPrice = 105.0,
                    TradeDate = DateTime.Now,
                    TradeSecurity = "SEC789",
                    TradeStatus = "Pending",
                    Trader = "Trader3",
                    Benchmark = "Benchmark3",
                    Book = "BookC",
                    CreationName = "Admin",
                    CreationDate = DateTime.Now,
                    RevisionName = "Admin",
                    RevisionDate = DateTime.Now,
                    DealName = "DealGamma",
                    DealType = "Type3",
                    SourceListId = "SRC003",
                    Side = "Buy"
                }
            };

            context.Trades.AddRange(trades);
            context.SaveChanges();
        }

        public void InitializeUser(LocalDbContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin123", // ⚠️ En prod, ne jamais stocker en clair !
                    Fullname = "Administrator",
                    Role = "ADMIN"
                },
                new User
                {
                    UserName = "trader1",
                    Password = "trader123",
                    Fullname = "John Doe",
                    Role = "TRADER"
                },
                new User
                {
                    UserName = "user1",
                    Password = "user123",
                    Fullname = "Jane Smith",
                    Role = "USER"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
