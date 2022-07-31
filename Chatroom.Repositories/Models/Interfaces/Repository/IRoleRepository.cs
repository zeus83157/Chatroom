using Chatroom.Repositories.Models.Entities;

namespace Chatroom.Repositories.Models.Interfaces.Repository
{
    public interface IRoleRepository
    {
        RoleEntity GetByName(string name);
    }
}
