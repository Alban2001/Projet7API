using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public LocalDbContext DbContext { get; }

        public RatingRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Rating>> FindAll()
        {
            return await DbContext.Ratings.ToListAsync();
        }

        public void Add(Rating rating)
        {
            DbContext.Ratings.Add(rating);
            DbContext.SaveChanges();
        }

        public void Update(Rating rating)
        {
            DbContext.Ratings.Update(rating);
            DbContext.SaveChanges();
        }

        public void Delete(Rating rating)
        {
            DbContext.Ratings.Remove(rating);
            DbContext.SaveChanges();
        }

        public async Task<Rating> FindById(int id)
        {
            Rating rating = await DbContext.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            if (rating == null) {
                return null;
            }
            return rating;
        }
    }
}