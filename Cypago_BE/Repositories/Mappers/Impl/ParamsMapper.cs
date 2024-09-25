using DAL;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces;

namespace Repositories.Mappers
{
    public class ParamsMapper : IParamsMapper
    {
        public DALQueryParams GetDALParamsFromDTOParams(DTOQueryParams dtoQueryParams)
        {
            DALQueryParams result = new DALQueryParams
            {
                PageNum = dtoQueryParams.PageNum,
                PageSize = dtoQueryParams.PageSize,
            };
            foreach (KeyValuePair<string, string> paramItem in dtoQueryParams.FilterParams)
            {
                result.FilterParams.Add(paramItem.Key, paramItem.Value);
            }

            return result;
        }
    }
}
