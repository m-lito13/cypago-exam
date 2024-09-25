using DAL.Models;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces.interfaces;

namespace Repositories.Mappers.Impl
{
    public class ScanMapper : IScanMapper
    {
        public ScanDTO GetScanDTOFromModel(ScanModel scanModel)
        {
            ScanDTO result = new ScanDTO
            {
                Id = scanModel.Id,
                StartTime = scanModel.Start,
                EndTime = scanModel.Finish
            };
            return result;
        }
    }
}
