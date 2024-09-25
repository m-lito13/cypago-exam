using CypagoApp.Mappers.Interfaces;
using CypagoApp.Requests;
using Microsoft.AspNetCore.Mvc;
using RepositoryInterfaces;
using RepositoryInterfaces.interfaces;
using ServiceInterfaces;

namespace CypagoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScansController : Controller
    {
        private readonly IScansService _scansService;
        private readonly ILogger _logger;
        private readonly IScanRequestMapper _scanRequestMapper;
        private readonly IQueryParamsMapper _queryParamsMapper;

        public ScansController(IScansService scansService, IScanRequestMapper scanRequestMapper, IQueryParamsMapper queryParamsMapper, ILogger<ScansController> logger)
        {
            _scansService = scansService;
            _logger = logger;
            _scanRequestMapper = scanRequestMapper;
            _queryParamsMapper = queryParamsMapper;
        }

        [HttpGet("")]
        public IEnumerable<ScanDTO> Get([FromQuery] CommonQueryParameters queryParams)
        {
            DTOQueryParams dtoQueryParams = _queryParamsMapper.GetDTOQueryParamsFromCommonQueryParams(queryParams);
            return _scansService.GetAllScans(dtoQueryParams);
        }

        [HttpPost]
        public IActionResult CreateScan([FromBody] CreateScanRequest createScanRequest)
        {
            _logger.LogInformation("CreateScan enter");
            CreateScanDTO createScanDTO = _scanRequestMapper.GetCreateScanDTOFromRequest(createScanRequest);
            _scansService.AddScan(createScanDTO);
            return Json(StatusCode(StatusCodes.Status200OK));
        }

    }
}
