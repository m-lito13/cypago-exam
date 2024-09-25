using DAL.Models;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace Repositories.Mappers.Impl
{
    public class ResourceMapper : IResourceMapper
    {
        public ResourceDTO GetResourceDTOFromModel(ResourceModel resourceModel)
        {
            ResourceType resourceTypeToSet = (ResourceType)Enum.Parse(typeof(ResourceType), resourceModel.ResourceType, true);
            ResourceDTO result = new ResourceDTO
            {
                Data = resourceModel.Data,
                DataHash = resourceModel.DataHash,
                Name = resourceModel.Name,
                Urn = resourceModel.URN,
                ResourceType = resourceTypeToSet,
                ScanID = resourceModel.ScanID,
            };
            return result;
        }

        public ResourceModel GetResourceModelFromDTO(ResourceDTO resourceDTO)
        {
            ResourceModel result = new ResourceModel
            {
                Name = resourceDTO.Name,
                ScanID = resourceDTO.ScanID,
                Data = resourceDTO.Data,
                DataHash = resourceDTO.DataHash,
                URN = resourceDTO.Urn,
                ResourceType = resourceDTO.ResourceType.ToString(),
            };
            return result;
        }
    }
}
