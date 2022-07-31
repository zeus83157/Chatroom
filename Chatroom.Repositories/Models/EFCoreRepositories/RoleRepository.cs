using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Entities;
using Chatroom.Repositories.Models.Interfaces.Repository;

namespace Chatroom.Repositories.Models.EFCoreRepositories
{
    public class RoleRepository : IRoleRepository
    {
        SampleDBContext _SampleDBContext;
        public RoleRepository(SampleDBContext sampleDBContext)
        {
            _SampleDBContext = sampleDBContext;
        }

        public RoleEntity GetByName(string name)
        {
            var role = _SampleDBContext.Role.FirstOrDefault(x => x.RoleName == name);
            if (role == null)
                return null;

            return new RoleEntity
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                CreateDatetime = role.CreateDatetime,
                UpdatedDatetime = role.UpdatedDatetime
            };
        }
    }
}
