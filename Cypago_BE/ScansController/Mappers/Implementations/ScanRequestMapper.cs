using CypagoApp.Mappers.Interfaces;
using CypagoApp.Requests;
using RepositoryInterfaces.interfaces;

namespace CypagoApp.Mappers.Implementations
{
    public class ScanRequestMapper : IScanRequestMapper
    {
        public CreateScanDTO GetCreateScanDTOFromRequest(CreateScanRequest request)
        {
            CreateScanDTO result = new CreateScanDTO
            {
                StartTime = DateTime.ParseExact(request.Started, "dd-MM-yyyy HH:mm:ss", null),
                EndTime = DateTime.ParseExact(request.Finished, "dd-MM-yyyy HH:mm:ss", null)
            };
            return result;
        }
    }
}
