using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.API
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IAnimalRepository Animals { get; }
        ICommentRepository Comments { get; }
        void Complete();
    }
}
