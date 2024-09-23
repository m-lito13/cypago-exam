using ServiceInterfaces.DTO;

namespace ServiceInterfaces
{
    public interface IScansService
    {
        void AddScan(CreateScanDTO createScanDTO);
        List<ScanDTO> GetScans();
    }
}
