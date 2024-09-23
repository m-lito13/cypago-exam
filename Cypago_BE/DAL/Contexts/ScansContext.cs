using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Contexts
{
    internal class ScansContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<ScanModel> ScanModels { get; set; }

        public ScansContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
