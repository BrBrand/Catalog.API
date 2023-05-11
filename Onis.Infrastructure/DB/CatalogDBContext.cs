using Microsoft.EntityFrameworkCore;
using Onis.Domain.Entities;
using System.Reflection;

namespace Onis.Infrastructure.DB
{
    //TODO
    public class CatalogDBContext : DbContext
    {

        

        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
        {

        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}
