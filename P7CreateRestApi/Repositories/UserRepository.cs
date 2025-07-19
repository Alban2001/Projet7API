using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository
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
        }

        public void Update(User user)
        {
            DbContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            DbContext.Users.Remove(user);
        }

        public User FindById(int id)
        {
            User unUser = DbContext.Users.Find(id);
            if (unUser == null) {
                return null;
            }
            return unUser;
        }
    }
}