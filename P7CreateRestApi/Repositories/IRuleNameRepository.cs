using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRuleNameRepository
    {
        RuleName FindByName(string name);
        Task<List<RuleName>> FindAll();
        void Add(RuleName ruleName);
        void Update(RuleName ruleName);
        void Delete(RuleName ruleName);
        Task<RuleName> FindById(int id);
    }
}
