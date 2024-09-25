using BuisnessLayerServiceInterfaces;
using CypagoApp.Mappers.Interfaces;
using CypagoApp.Requests;
using Microsoft.AspNetCore.Mvc;
using RepositoryInterfaces;
using RepositoryInterfaces.DTO;

namespace CypagoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourcesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IResourcesService _resourcesService;
        private readonly IResourceRequestMapper _resourceRequestMapper;
        private readonly IQueryParamsMapper _queryParamsMapper;
        public ResourcesController(IResourceRequestMapper resourceRequestMapper,
            IResourcesService resourcesService,
            IQueryParamsMapper queryParamsMapper,
            ILogger<ResourcesController> logger)
        {
            _logger = logger;
            _resourceRequestMapper = resourceRequestMapper;
            _resourcesService = resourcesService;
            _queryParamsMapper = queryParamsMapper;
        }

        [HttpPost]
        public IActionResult CreateResource([FromBody] CreateResourceRequest createResourceRequest)
        {
            _logger.LogInformation("CreateResource enter");
            ResourceDTO createResourceDTO = _resourceRequestMapper.GetCreateResourceDTOFromRequest(createResourceRequest);
            _resourcesService.CreateResource(createResourceDTO);
            return Json(StatusCode(StatusCodes.Status200OK));
        }

        [HttpGet]
        public List<ResourceDTO> GetResources([FromQuery] ResourcesQueryParameters resourcesQueryParameters)
        {
            _logger.LogInformation("GetResources enter");
            DTOQueryParams dtoQueryParams = _queryParamsMapper.GetDTOQueryParamsFromResourcesQueryParams(resourcesQueryParameters);
            List<ResourceDTO> result = _resourcesService.GetResources(dtoQueryParams).ToList();
            return result;
        }
    }
}
