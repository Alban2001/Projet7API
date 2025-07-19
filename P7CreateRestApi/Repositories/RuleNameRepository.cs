using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class RuleNameRepository
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
        }

        public void Update(RuleName ruleName)
        {
            DbContext.RuleNames.Update(ruleName);
        }

        public void Delete(RuleName ruleName)
        {
            DbContext.RuleNames.Remove(ruleName);
        }

        public RuleName FindById(int id)
        {
            RuleName ruleName = DbContext.RuleNames.Find(id);
            if (ruleName == null) {
                return null;
            }
            return ruleName;
        }
    }
}