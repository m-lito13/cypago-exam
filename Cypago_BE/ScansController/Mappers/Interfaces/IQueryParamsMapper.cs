using RepositoryInterfaces;

namespace CypagoApp.Mappers.Interfaces
{
    public interface IQueryParamsMapper
    {
        DTOQueryParams GetDTOQueryParamsFromResourcesQueryParams(ResourcesQueryParameters resourcesQueryParameters);
        DTOQueryParams GetDTOQueryParamsFromCommonQueryParams(CommonQueryParameters commonQueryParams);
    }
}
