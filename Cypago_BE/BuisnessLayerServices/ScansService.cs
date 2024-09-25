using Microsoft.Extensions.Logging;
using RepositoryInterfaces;
using RepositoryInterfaces.interfaces;
using ServiceInterfaces;

namespace BuisnessLayerServices
{
    public class ScansService : IScansService
    {
        private readonly IScansRepository _scansRepository;
        private readonly ILogger _logger;

        public ScansService(
            IScansRepository scansRepository,
            ILogger<ScansService> logger)
        {
            _scansRepository = scansRepository;
            _logger = logger;
        }

        public void AddScan(CreateScanDTO createScanDTO)
        {
            _logger.LogInformation("AddScan enter");
            if (createScanDTO.StartTime > createScanDTO.EndTime)
            {
                throw new ArgumentException("Start time cannot be greater than end time");
            }
            _scansRepository.CreateScan(createScanDTO.StartTime, createScanDTO.EndTime);

        }

        public IEnumerable<ScanDTO> GetAllScans(DTOQueryParams dtoQueryParams)
        {
            return _scansRepository.GetAllScans(dtoQueryParams);
        }

    }
}
