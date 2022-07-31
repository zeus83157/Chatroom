using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Entities;
using Chatroom.Repositories.Models.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

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

        public void InsertUpdate(UserEntity userEntity)
        {
            var user = GetByUsername(userEntity.UserName);
            if (user == null)
                _SampleDBContext.User.Add(new User
                {
                    StarSignID = userEntity.StarSignID,
                    CreateDatetime = userEntity.CreateDatetime,
                    Email = userEntity.Email,
                    Gender = userEntity.Gender,
                    Password = userEntity.Password,
                    UpdatedDatetime = userEntity.UpdatedDatetime,
                    UserID = userEntity.UserID,
                    UserName = userEntity.UserName
                });
            else
            {
                user.StarSignID = userEntity.StarSignID;
                user.CreateDatetime = userEntity.CreateDatetime;
                user.Email = userEntity.Email;
                user.Gender = userEntity.Gender;
                user.Password = userEntity.Password;
                user.UpdatedDatetime = userEntity.UpdatedDatetime;
                user.UserID = userEntity.UserID;
                user.UserName = userEntity.UserName;

                _SampleDBContext.Entry(user).State = EntityState.Modified;
            }
        }
    }
}
