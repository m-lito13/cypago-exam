using DAL.Models;

namespace DAL.Interfaces
{
    public interface IResourcesDAL
    {
        void AddResource(ResourceModel modelToAdd);
        List<ResourceModel> GetResources(DALQueryParams queryParams);
    }
}
