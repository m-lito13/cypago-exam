using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Logging;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces;
using RepositoryInterfaces.interfaces;

namespace Repositories
{
    public class ScansRepository : IScansRepository
    {
        private readonly IScansDAL _scansDAL;
        private readonly ILogger _logger;
        private readonly IScanMapper _scanMapper;
        private readonly IParamsMapper _paramsMapper;

        public ScansRepository(IScansDAL scansDAL, IScanMapper scanMapper, IParamsMapper paramsMapper, ILogger<ScansRepository> logger)
        {
            _scansDAL = scansDAL;
            _logger = logger;
            _scanMapper = scanMapper;
            _paramsMapper = paramsMapper;
        }
        public void CreateScan(DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("CreateScan enter");
            _scansDAL.AddScan(startDate, endDate);
        }

        public IEnumerable<ScanDTO> GetAllScans(DTOQueryParams dtoQueryParams)
        {
            DALQueryParams dalQueryParams = _paramsMapper.GetDALParamsFromDTOParams(dtoQueryParams);
            List<ScanModel> dataFromDB = _scansDAL.GetAllScans(dalQueryParams);
            List<ScanDTO> result = dataFromDB.Select(modelItem => _scanMapper.GetScanDTOFromModel(modelItem)).ToList();
            return result;
        }
    }
}
