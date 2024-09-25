using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class ResourcesDAL : IResourcesDAL
    {
        IConfiguration _configuration;
        public ResourcesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void AddResource(ResourceModel modelToAdd)
        {
            using (ResourcesContext db = new ResourcesContext(_configuration))
            {
                db.ResourceModels.Add(modelToAdd);
                db.SaveChanges();
            }
        }

        public List<ResourceModel> GetResources(DALQueryParams queryParams)
        {
            using (ResourcesContext db = new ResourcesContext(_configuration))
            {
                Expression<Func<ResourceModel, bool>> filterExpr = QueryHelper.GetQueryExpression(queryParams);
                List<ResourceModel> result = (queryParams.UsePagination())
                        ? db.ResourceModels
                            .Where(filterExpr)
                            .Skip((queryParams.PageNum - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList()
                        : db.ResourceModels
                            .Where(filterExpr).ToList();
                return result;
            }
        }


    }
}
