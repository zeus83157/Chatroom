using Chatroom.Repositories.Models.Entities;
using Chatroom.Repositories.Models.Interfaces.Repository;
using Chatroom.Repositories.Models.Interfaces.UnitOfWork;
using Chatroom.Utilities.Enums;
using Chatroom.Utilities.Extensions;
using Chatroom.Utilities.Models;

namespace Chatroom.Utilities.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserRepository _UserRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUsersWithRoleRepository _UsersWithRoleRepository;
        public AccountService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUsersWithRoleRepository usersWithRoleRepository)
        {
            _UnitOfWork = unitOfWork;
            _UserRepository = userRepository;
            _RoleRepository = roleRepository;
            _UsersWithRoleRepository = usersWithRoleRepository;
        }

        public bool CreateUser(AccountData model)
        {
            var user = _UserRepository.GetByUsername(model.UserName);
            var role = _RoleRepository.GetByName(RoleType.Normal.ToString());
            if (user != null || role == null)
                return false;

            model.UserID = Guid.NewGuid();
            _UserRepository.InsertUpdate(new UserEntity
            {
                UserID = model.UserID,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                Password = model.Password.EncryptBySHA256(),
                CreateDatetime = DateTime.UtcNow,
                UpdatedDatetime = DateTime.UtcNow
            });

            _UsersWithRoleRepository.InsertUpdate(new UsersWithRoleEntity
            {
                ID = Guid.NewGuid(),
                RoleID = role.RoleID,
                UserID = model.UserID,
                CreateDatetime = DateTime.UtcNow,
                UpdatedDatetime = DateTime.UtcNow
            });

            return _UnitOfWork.Save();
        }
    }
}
