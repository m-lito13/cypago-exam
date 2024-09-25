using CommonInfra;
using DAL.Models;
using LinqKit;
using System.Linq.Expressions;

namespace DAL
{
    internal class QueryHelper
    {
        public static Expression<Func<ResourceModel, bool>> GetQueryExpression(DALQueryParams queryParams)
        {
            Expression<Func<ResourceModel, bool>>? expr = PredicateBuilder.New<ResourceModel>(true);
            if (queryParams.FilterParams.ContainsKey(Constants.SCAN_ID))
            {
                //Here can be parse exception - will be handled on app layer 
                int scanIdToFind = int.Parse(queryParams.FilterParams[Constants.SCAN_ID]);
                expr = expr.And(item => item.ScanID == scanIdToFind);
            }

            if (queryParams.FilterParams.ContainsKey(Constants.RESOURCE_TYPE))
            {
                string resourceTypeToFind = queryParams.FilterParams[Constants.RESOURCE_TYPE];
                expr = expr.And(item => item.ResourceType == resourceTypeToFind);
            }

            return expr;
        }
    }
}
