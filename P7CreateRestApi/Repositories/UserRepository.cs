using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public LocalDbContext DbContext { get; }

        public UserRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User FindByUserName(string userName)
        {
            User unUser = DbContext.Users.Where(user => user.UserName == userName).FirstOrDefault();
            if (unUser == null)
            {
                return null;
            }
            return unUser;
        }

        public async Task<List<User>> FindAll()
        {
            return await DbContext.Users.ToListAsync();
        }

        public void Add(User user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }

        public void Update(User user)
        {
            DbContext.Users.Update(user);
            DbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();
        }

        public async Task<User> FindById(int id)
        {
            User unUser = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (unUser == null) {
                return null;
            }
            return unUser;
        }
    }
}