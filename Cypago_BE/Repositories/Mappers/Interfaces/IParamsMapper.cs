using DAL;
using RepositoryInterfaces;

namespace Repositories.Mappers.Interfaces
{
    public interface IParamsMapper
    {
        DALQueryParams GetDALParamsFromDTOParams(DTOQueryParams dtoQueryParams);
    }
}
