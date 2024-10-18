using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Contexts
{
    public class ResourcesContext : DbContext
    {
        public DbSet<ResourceModel> ResourceModels { get; set; }
        public ResourcesContext(DbContextOptions options) : base(options)
        {
        }

    }
}
