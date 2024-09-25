using BuisnessLayerServiceInterfaces;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace BuisnessLayerServices
{
    public class ResourcesService : IResourcesService
    {
        private readonly ILogger _logger;
        private readonly IResourcesRepository _resourcesRepository;
        public ResourcesService(IResourcesRepository resourcesRepository, ILogger<ResourcesService> logger)
        {
            _resourcesRepository = resourcesRepository;
            _logger = logger;
        }
        public void CreateResource(ResourceDTO createResourceDTO)
        {
            _logger.LogInformation("CreateResource enter");
            _resourcesRepository.AddResource(createResourceDTO);
        }

        public IEnumerable<ResourceDTO> GetResources(DTOQueryParams dtoQueryParams)
        {
            _logger.LogInformation("GetResources enter");
            return _resourcesRepository.GetResources(dtoQueryParams);
        }
    }
}
