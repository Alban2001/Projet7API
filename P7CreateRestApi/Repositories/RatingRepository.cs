using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class RatingRepository
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
        }

        public void Update(Rating rating)
        {
            DbContext.Ratings.Update(rating);
        }

        public void Delete(Rating rating)
        {
            DbContext.Ratings.Remove(rating);
        }

        public Rating FindById(int id)
        {
            Rating rating = DbContext.Ratings.Find(id);
            if (rating == null) {
                return null;
            }
            return rating;
        }
    }
}