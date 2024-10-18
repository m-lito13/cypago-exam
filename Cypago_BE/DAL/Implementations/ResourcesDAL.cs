using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class ResourcesDAL : IResourcesDAL
    {
        ResourcesContext _dbContext;
        public ResourcesDAL(ResourcesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddResource(ResourceModel modelToAdd)
        {
            _dbContext.ResourceModels.Add(modelToAdd);
            _dbContext.SaveChanges();
        }

        public List<ResourceModel> GetResources(DALQueryParams queryParams)
        {
            Expression<Func<ResourceModel, bool>> filterExpr = QueryHelper.GetQueryExpression(queryParams);
            List<ResourceModel> result = (queryParams.UsePagination())
                    ? _dbContext.ResourceModels
                        .Where(filterExpr)
                        .Skip((queryParams.PageNum - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList()
                    : _dbContext.ResourceModels
                        .Where(filterExpr).ToList();
            return result;
        }


    }
}
