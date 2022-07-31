using Chatroom.Repositories.Models.Entities;

namespace Chatroom.Repositories.Models.Interfaces.Repository
{
    public interface IUserRepository
    {
        public UserEntity GetByUsername(string username);
        public void InsertUpdate(UserEntity userEntity);
    }
}
