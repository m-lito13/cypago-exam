using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DAL.Contexts
{
    internal class ResourcesContext : CommonContext
    {
        public DbSet<ResourceModel> ResourceModels { get; set; }
        public ResourcesContext(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
