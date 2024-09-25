
using RepositoryInterfaces;
using RepositoryInterfaces.interfaces;

namespace ServiceInterfaces
{
    public interface IScansService
    {
        void AddScan(CreateScanDTO createScanDTO);
        IEnumerable<ScanDTO> GetAllScans(DTOQueryParams dtoQueryParams);
    }
}
