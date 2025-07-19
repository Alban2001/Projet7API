using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class CurvePointRepository
    {
        public LocalDbContext DbContext { get; }

        public CurvePointRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public CurvePoint FindByCurvePointValue(double CurvePointValue)
        {
            CurvePoint curve = DbContext.CurvePoints.Where(curve => curve.CurvePointValue == CurvePointValue).FirstOrDefault();
            if (curve == null)
            {
                return null;
            }
            return curve;
        }

        public async Task<List<CurvePoint>> FindAll()
        {
            return await DbContext.CurvePoints.ToListAsync();
        }

        public void Add(CurvePoint curve)
        {
            DbContext.CurvePoints.Add(curve);
        }

        public void Update(CurvePoint curve)
        {
            DbContext.CurvePoints.Update(curve);
        }

        public void Delete(CurvePoint curve)
        {
            DbContext.CurvePoints.Remove(curve);
        }

        public CurvePoint FindById(int id)
        {
            CurvePoint curve = DbContext.CurvePoints.Find(id);
            if (curve == null) {
                return null;
            }
            return curve;
        }
    }
}