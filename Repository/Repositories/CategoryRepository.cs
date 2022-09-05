using Contract.API;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class CategoryRepository: BaseRepository<Category> ,ICategoryRepository
    {
        public CategoryRepository(PetShopDbContext context): base(context)
        {

        }
    }
}
