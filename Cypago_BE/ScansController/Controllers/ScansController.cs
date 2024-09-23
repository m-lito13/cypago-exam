using CypagoApp.Requests;
using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using ServiceInterfaces.DTO;

namespace CypagoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScansController : Controller
    {
        IScansService _scansService;

        public ScansController(IScansService scansService)
        {
            _scansService = scansService;
        }

        [HttpGet("")]
        public IEnumerable<Object> Get()
        {
            return null;
        }

        [HttpPost("/create")]
        public IActionResult CreateScan([FromBody] CreateScanRequest scanData)
        {
            //_logger.LogInformation("{controller} AddTransaction enter", nameof(ParkingTransactionsController));
            //EntityConverter converter = new EntityConverter();
            //TransactionDTO transactionDTO = converter.GetTransactionDTOFromRequest(trasactionData);
            //_parkingService.AddTransaction(transactionDTO);

            CreateScanDTO createScanDTO = GetCreateScanDTO(scanData);
            _scansService.AddScan(createScanDTO);
            return StatusCode(StatusCodes.Status200OK);
        }

        private CreateScanDTO GetCreateScanDTO(CreateScanRequest createScanRequest)
        {
            CreateScanDTO result = new CreateScanDTO
            {
                StartTime = DateTime.ParseExact(createScanRequest.Started,"dd-MM-yyyy HH:mm:ss", null),
                EndTime = DateTime.ParseExact(createScanRequest.Finished, "dd-MM-yyyy HH:mm:ss", null)

            };
            return result;
        }

    }
}
