using DAL.Interfaces;
using RepositoryInterfaces;

namespace Repositories
{
    public class ScansEFRepository : IScansRepository
    {
        IScansDAL _scansDAL;

        public ScansEFRepository(IScansDAL scansDAL)
        {
            _scansDAL = scansDAL;
        }
        public void CreateScan(DateTime startDate, DateTime endDate)
        {
            _scansDAL.AddScan(startDate, endDate);
        }
    }
}
