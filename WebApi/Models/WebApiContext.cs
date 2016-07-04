
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}