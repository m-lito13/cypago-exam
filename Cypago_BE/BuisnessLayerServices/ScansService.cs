using RepositoryInterfaces;
using ServiceInterfaces;
using ServiceInterfaces.DTO;

namespace BuisnessLayerServices
{
    public class ScansService : IScansService
    {
        private readonly IScansRepository _scansRepository;
        private readonly IResourcesRepository _resoucresRepository;

        public ScansService(IScansRepository scansRepository, IResourcesRepository resoucresRepository)
        {
            _scansRepository = scansRepository;
            _resoucresRepository = resoucresRepository;
        }

        public void AddScan(CreateScanDTO createScanDTO)
        {
            _scansRepository.CreateScan(createScanDTO.StartTime, createScanDTO.EndTime);

        }

        List<ScanDTO> IScansService.GetScans()
        {
            throw new NotImplementedException();
        }
    }
}
