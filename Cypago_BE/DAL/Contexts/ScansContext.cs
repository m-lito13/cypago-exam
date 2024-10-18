using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
    public class ScansContext : DbContext
    {
        public DbSet<ScanModel> ScanModels { get; set; }
        public ScansContext(DbContextOptions options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
