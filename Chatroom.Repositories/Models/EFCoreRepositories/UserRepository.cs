using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Entities;
using Chatroom.Repositories.Models.Interfaces.Repository;

namespace Chatroom.Repositories.Models.EFCoreRepositories
{
    public class UserRepository : IUserRepository
    {
        readonly SampleDBContext _SampleDBContext;
        public UserRepository(SampleDBContext sampleDBContext)
        {
            _SampleDBContext = sampleDBContext;
        }

        public UserEntity GetByUsername(string username)
        {
            var user = _SampleDBContext.User.FirstOrDefault(x => x.UserName.ToUpper() == username.ToUpper());
            if (user == null)
                return null;

            return new UserEntity
            {
                StarSignID = user.StarSignID,
                CreateDatetime = user.CreateDatetime,
                Email = user.Email,
                Gender = user.Gender,
                Password = user.Password,
                UpdatedDatetime = user.UpdatedDatetime,
                UserID = user.UserID,
                UserName = username
            };
        }
    }
}
