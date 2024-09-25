using CypagoApp.Requests;
using RepositoryInterfaces.DTO;

namespace CypagoApp.Mappers.Interfaces
{
    public interface IResourceRequestMapper
    {
        ResourceDTO GetCreateResourceDTOFromRequest(CreateResourceRequest request);
    }
}
