using CommonInfra;
using CypagoApp.Mappers.Interfaces;
using CypagoApp.Requests;
using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace CypagoApp.Mappers.Implementations
{
    public class ResourceRequestMapper : IResourceRequestMapper
    {
        public ResourceDTO GetCreateResourceDTOFromRequest(CreateResourceRequest request)
        {
            ResourceType resourceTypeToSet;
            bool isValid = Enum.TryParse(request.ResourceType.ToUpper(), out resourceTypeToSet);
            if (!isValid)
            {
                throw new ArgumentException("Request contains invalid ResourceType");
            }
            ResourceDTO result = new ResourceDTO
            {
                Name = request.Name,
                Data = request.Data,
                ScanID = request.ScanId,
                Urn = request.Urn,
                ResourceType = resourceTypeToSet,
                DataHash = EncryptionHelper.GetHashForString(request.Data)
            };
            return result;
        }

    }
}
