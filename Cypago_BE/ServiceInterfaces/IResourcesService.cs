using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace BuisnessLayerServiceInterfaces
{
    public interface IResourcesService
    {
        void CreateResource(ResourceDTO createResourceDTO);
        IEnumerable<ResourceDTO> GetResources(DTOQueryParams dtoQueryParams);
    }
}
