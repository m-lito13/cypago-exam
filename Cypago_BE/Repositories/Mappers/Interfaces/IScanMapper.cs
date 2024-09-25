using DAL.Models;
using RepositoryInterfaces.interfaces;

namespace Repositories.Mappers.Interfaces
{
    public interface IScanMapper
    {
        ScanDTO GetScanDTOFromModel(ScanModel scanModel);
    }
}
