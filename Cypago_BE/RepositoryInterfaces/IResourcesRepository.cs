using RepositoryInterfaces.DTO;

namespace RepositoryInterfaces
{
    public interface IResourcesRepository
    {
        void AddResource(ResourceDTO createResourceDTO);
        IEnumerable<ResourceDTO> GetResources(DTOQueryParams dtoQueryParams);
    }
}
