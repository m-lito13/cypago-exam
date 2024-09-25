using CommonInfra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Contexts
{
    internal abstract class CommonContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public CommonContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetSection(Constants.CONNECTION_STRING)?.Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
