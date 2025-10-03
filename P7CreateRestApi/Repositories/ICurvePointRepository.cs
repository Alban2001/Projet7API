using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ICurvePointRepository
    {
        CurvePoint FindByCurvePointValue(double CurvePointValue);
        Task<List<CurvePoint>> FindAll();
        void Add(CurvePoint curve);
        void Update(CurvePoint curve);
        void Delete(CurvePoint curve);
        Task<CurvePoint> FindById(int id);
    }
}
