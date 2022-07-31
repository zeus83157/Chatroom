using Chatroom.Repositories.Models.Interfaces.Repository;
using Chatroom.Utilities.Extensions;
using Chatroom.Utilities.Models;

namespace Chatroom.Utilities.Services
{
    public class AuthService
    {
        private readonly IUserRepository _UserRepository;
        public AuthService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public bool ValidateUser(LoginData model)
        {
            var user = _UserRepository.GetByUsername(model.UserName);
            if (user == null)
                return false;
            var cyphertext = model.Password?.EncryptBySHA256();
            return user.Password == cyphertext;
        }
    }
}
