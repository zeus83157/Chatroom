using Chatroom.Repositories.Models.Entities;

namespace Chatroom.Repositories.Models.Interfaces.Repository
{
    public interface IUsersWithRoleRepository
    {
        void InsertUpdate(UsersWithRoleEntity usersWithRoleEntity);
    }
}
