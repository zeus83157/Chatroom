using Chatroom.Utilities.Models;
using Chatroom.Utilities.Services;
using Chatroom.WebAPI.Helpers;
using Chatroom.WebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chatroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;
        private readonly AuthService _authService;
        public AuthController(JwtHelper jwtHelper, AuthService authService)
        {
            _jwtHelper = jwtHelper;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            var loginData = new LoginData { Password = model.Password, UserName = model.UserName };
            if (_authService.ValidateUser(loginData))
            {
                var token = _jwtHelper.GenerateToken(model.UserName.ToString());
                return Ok(new { token });
            }
            return BadRequest();
        }
    }
}
