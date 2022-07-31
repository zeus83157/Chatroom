using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Interfaces.UnitOfWork;

namespace Chatroom.Repositories.Models.UnitOfWorks
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly SampleDBContext _SampleDBContext;
        public EFCoreUnitOfWork(SampleDBContext sampleDBContext)
        {
            _SampleDBContext = sampleDBContext;
        }

        public bool Save()
        {
            return _SampleDBContext.SaveChanges() > 0;
        }
    }
}
