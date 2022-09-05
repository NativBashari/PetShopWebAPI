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
    internal class CommentRepository: BaseRepository<Comment> ,ICommentRepository
    {
        public CommentRepository(PetShopDbContext context): base(context)
        {

        }
    }
}
