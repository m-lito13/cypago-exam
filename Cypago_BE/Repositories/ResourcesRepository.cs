using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Logging;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        private readonly ILogger _logger;
        private readonly IResourcesDAL _resourcesDAL;
        private readonly IResourceMapper _resourceMapper;
        private readonly IParamsMapper _paramsMapper;
        public ResourcesRepository(IResourcesDAL resoursesDAL, IResourceMapper resourceMapper, IParamsMapper paramsMapper, ILogger<ResourcesRepository> logger)
        {
            _resourcesDAL = resoursesDAL;
            _logger = logger;
            _resourceMapper = resourceMapper;
            _paramsMapper = paramsMapper;
        }
        public void AddResource(ResourceDTO createResourceDTO)
        {
            _logger.LogInformation("AddResource enter");
            ResourceModel modelToAdd = _resourceMapper.GetResourceModelFromDTO(createResourceDTO);
            _resourcesDAL.AddResource(modelToAdd);
        }

        public IEnumerable<ResourceDTO> GetResources(DTOQueryParams dtoQueryParams)
        {
            _logger.LogInformation("GetResources enter");
            DALQueryParams paramsVal = _paramsMapper.GetDALParamsFromDTOParams(dtoQueryParams);
            List<ResourceModel> resourcesFromDb = _resourcesDAL.GetResources(paramsVal);
            List<ResourceDTO> result = resourcesFromDb.Select(modelItem => _resourceMapper.GetResourceDTOFromModel(modelItem)).ToList();
            return result;
        }
    }
}
