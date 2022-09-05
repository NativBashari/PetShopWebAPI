using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PetShopDbContext: DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals{ get; set; }
        public DbSet<Comment>? Comments { get; set; }

        public PetShopDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=PetShop;Integrated Security=True");
            optionsBuilder.UseLazyLoadingProxies(); // Use lazy loading to get complex objects in one query.
        }
    }
}
