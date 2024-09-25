using CypagoApp.Requests;
using RepositoryInterfaces.interfaces;

namespace CypagoApp.Mappers.Interfaces
{
    public interface IScanRequestMapper
    {
        CreateScanDTO GetCreateScanDTOFromRequest(CreateScanRequest request);
    }
}
