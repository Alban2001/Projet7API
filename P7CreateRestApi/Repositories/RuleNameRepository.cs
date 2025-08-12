using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class RuleNameRepository : IRuleNameRepository
    {
        public LocalDbContext DbContext { get; }

        public RuleNameRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public RuleName FindByName(string name)
        {
            RuleName ruleName = DbContext.RuleNames.Where(ruleName => ruleName.Name == name).FirstOrDefault();
            if (ruleName == null)
            {
                return null;
            }
            return ruleName;
        }

        public async Task<List<RuleName>> FindAll()
        {
            return await DbContext.RuleNames.ToListAsync();
        }

        public void Add(RuleName ruleName)
        {
            DbContext.RuleNames.Add(ruleName);
            DbContext.SaveChanges();
        }

        public void Update(RuleName ruleName)
        {
            DbContext.RuleNames.Update(ruleName);
            DbContext.SaveChanges();
        }

        public void Delete(RuleName ruleName)
        {
            DbContext.RuleNames.Remove(ruleName);
            DbContext.SaveChanges();
        }

        public async Task<RuleName> FindById(int id)
        {
            RuleName ruleName = await DbContext.RuleNames.FirstOrDefaultAsync(rn => rn.Id == id);
            if (ruleName == null) {
                return null;
            }
            return ruleName;
        }
    }
}