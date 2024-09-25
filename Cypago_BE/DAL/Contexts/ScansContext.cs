using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Contexts
{
    internal class ScansContext : CommonContext
    {
        public DbSet<ScanModel> ScanModels { get; set; }
        public ScansContext(IConfiguration configuration) : base(configuration) { 
        }
    }
}
