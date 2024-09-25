using CommonInfra;
using CypagoApp.Mappers.Interfaces;
using RepositoryInterfaces;

namespace CypagoApp.Mappers.Implementations
{
    public class QueryParamsMapper : IQueryParamsMapper
    {
        public DTOQueryParams GetDTOQueryParamsFromCommonQueryParams(CommonQueryParameters commonQueryParams)
        {
            DTOQueryParams result = new DTOQueryParams
            {
                PageNum = commonQueryParams.Page,
                PageSize = commonQueryParams.PageSize,
            };
            return result;
        }

        public DTOQueryParams GetDTOQueryParamsFromResourcesQueryParams(ResourcesQueryParameters resourcesQueryParameters)
        {
            DTOQueryParams result = GetDTOQueryParamsFromCommonQueryParams(resourcesQueryParameters);
            if (!string.IsNullOrEmpty(resourcesQueryParameters.ResourceType))
            {
                result.FilterParams.Add(Constants.RESOURCE_TYPE, resourcesQueryParameters.ResourceType);
            }

            if (resourcesQueryParameters.ScanID != null)
            {
                result.FilterParams.Add(Constants.SCAN_ID, resourcesQueryParameters.ScanID.Value.ToString());
            }

            return result;
        }
    }
}
