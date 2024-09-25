using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Implementations
{
    public class ScansDAL : IScansDAL
    {
        IConfiguration _configuration;
        public ScansDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ScanModel> GetAllScans(DALQueryParams queryParams)
        {
            using (ScansContext db = new ScansContext(_configuration))
            {
                List<ScanModel> result = (queryParams.UsePagination())
                        ? db.ScanModels
                            .Skip((queryParams.PageNum - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList()
                        : db.ScanModels.ToList();


                return result;
            }
        }

        public void AddScan(DateTime start, DateTime end)
        {
            using (ScansContext db = new ScansContext(_configuration))
            {
                ScanModel modelToAdd = new ScanModel
                {
                    Start = start,
                    Finish = end
                };
                db.ScanModels.Add(modelToAdd);
                db.SaveChanges();
            }
        }
    }
}
