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
    internal class AnimalRepository: BaseRepository<Animal> ,IAnimalRepository
    {
        PetShopDbContext context;
        public AnimalRepository(PetShopDbContext context): base(context)
        {
            this.context = context;
        }
        public IEnumerable<Animal> GetMostCommented()
        {
            return context.Animals.OrderByDescending(a => a.Comments.Count).Take(2);
        }
    }
}
