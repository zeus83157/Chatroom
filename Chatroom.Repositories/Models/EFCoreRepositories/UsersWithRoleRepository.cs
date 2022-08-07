using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Entities;
using Chatroom.Repositories.Models.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chatroom.Repositories.Models.EFCoreRepositories
{
    public class UsersWithRoleRepository : IUsersWithRoleRepository
    {
        private readonly SampleDBContext _SampleDBContext;
        public UsersWithRoleRepository(SampleDBContext sampleDBContext)
        {
            _SampleDBContext = sampleDBContext;
        }

        public UsersWithRoleEntity GetByID(Guid userid, Guid roleid)
        {
            var userWithRole = _SampleDBContext.UsersWithRole.FirstOrDefault(x => x.UserID == userid && x.RoleID == roleid);
            if (userWithRole == null)
                return null;

            return new UsersWithRoleEntity
            {
                RoleID = userWithRole.RoleID,
                UserID = userWithRole.UserID,
                ID = userWithRole.ID,
                CreateDatetime = userWithRole.CreateDatetime,
                UpdatedDatetime = userWithRole.UpdatedDatetime
            };
        }

        public void InsertUpdate(UsersWithRoleEntity usersWithRoleEntity)
        {
            var usersWithRole = GetByID(usersWithRoleEntity.UserID, usersWithRoleEntity.RoleID);
            if (usersWithRole == null)
                _SampleDBContext.UsersWithRole.Add(new UsersWithRole
                {
                    ID = usersWithRoleEntity.UserID,
                    UserID = usersWithRoleEntity.UserID,
                    RoleID = usersWithRoleEntity.RoleID,
                    CreateDatetime = usersWithRoleEntity.CreateDatetime,
                    UpdatedDatetime = usersWithRoleEntity.UpdatedDatetime
                });
            else
            {
                usersWithRole.UserID = usersWithRoleEntity.UserID;
                usersWithRole.RoleID = usersWithRoleEntity.RoleID;
                usersWithRole.UpdatedDatetime = usersWithRoleEntity.UpdatedDatetime;

                _SampleDBContext.Entry(usersWithRole).State = EntityState.Modified;
            }
        }
    }
}
