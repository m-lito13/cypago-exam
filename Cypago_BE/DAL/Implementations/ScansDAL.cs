using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementations
{
    public class ScansDAL : IScansDAL
    {
        ScansContext _dbContext;
        public ScansDAL(ScansContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<ScanModel> GetAllScans(DALQueryParams queryParams)
        {
            List<ScanModel> result = (queryParams.UsePagination())
                        ? _dbContext.ScanModels
                            .Skip((queryParams.PageNum - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList()
                        : _dbContext.ScanModels.ToList();


            return result;
        }

        public void AddScan(DateTime start, DateTime end)
        {
            ScanModel modelToAdd = new ScanModel
            {
                Start = start,
                Finish = end
            };
            _dbContext.ScanModels.Add(modelToAdd);
            _dbContext.SaveChanges();
        }
    }
}
