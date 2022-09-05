using Contract.API;
using Entities;
using Repository.Repositories;


namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PetShopDbContext context;
        IAnimalRepository? animalRepository;
        ICategoryRepository? categoryRepository;
        ICommentRepository? commentRepository;
        public UnitOfWork(PetShopDbContext context)
        {
            this.context = context;
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null) categoryRepository = new CategoryRepository(context);
                    return categoryRepository;
            }
        }

        public IAnimalRepository Animals
        {
            get
            {
                if(animalRepository == null) animalRepository = new AnimalRepository(context);
                return animalRepository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if(commentRepository == null) commentRepository = new CommentRepository(context);
                return commentRepository;
            }
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
