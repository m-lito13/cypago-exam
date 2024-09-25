using RepositoryInterfaces.interfaces;

namespace RepositoryInterfaces
{
    public interface IScansRepository
    {
        void CreateScan(DateTime startDate, DateTime endDate);
        IEnumerable<ScanDTO> GetAllScans(DTOQueryParams dtoQueryParams);
    }
}
