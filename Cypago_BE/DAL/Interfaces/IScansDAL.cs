using DAL.Models;

namespace DAL.Interfaces
{
    public interface IScansDAL
    {
        void AddScan(DateTime start, DateTime end);
        List<ScanModel> GetAllScans(DALQueryParams queryParams);
    }
}
