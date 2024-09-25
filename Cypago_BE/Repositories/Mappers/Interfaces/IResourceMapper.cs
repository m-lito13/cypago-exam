using DAL.Models;
using RepositoryInterfaces.DTO;

namespace Repositories.Mappers.Interfaces
{
    public interface IResourceMapper
    {
        ResourceModel GetResourceModelFromDTO(ResourceDTO resourceDTO);
        ResourceDTO GetResourceDTOFromModel(ResourceModel resourceModel);
    }
}
