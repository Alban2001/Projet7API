using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;
using System.Collections.Generic;

namespace Dot.Net.WebApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
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
            DbContext.SaveChanges();
        }

        public void Update(CurvePoint curve)
        {
            DbContext.CurvePoints.Update(curve);
            DbContext.SaveChanges();
        }

        public void Delete(CurvePoint curve)
        {
            DbContext.CurvePoints.Remove(curve);
            DbContext.SaveChanges();
        }

        public async Task<CurvePoint> FindById(int id)
        {
            CurvePoint curve = await DbContext.CurvePoints.FirstOrDefaultAsync(cp => cp.Id == id);
            if (curve == null) {
                return null;
            }
            return curve;
        }
    }
}