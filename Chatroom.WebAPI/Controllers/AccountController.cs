using Chatroom.Utilities.Models;
using Chatroom.Utilities.Services;
using Chatroom.WebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chatroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult Register(AccountViewModel accountViewModel)
        {
            var accountData = new AccountData
            {
                Email = accountViewModel.Email,
                Gender = accountViewModel.Gender,
                Password = accountViewModel.Password,
                UserName = accountViewModel.UserName,
                StarSignID = accountViewModel.StarSignID,
            };
            if (_accountService.CreateUser(accountData))
                return Ok();
            return BadRequest("Notthing Change.");
        }
    }
}
