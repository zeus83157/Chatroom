using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.WebAPI.Models.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var user = Context.User?.Identity?.Name;
            await Clients.All.SendAsync("ReceiveMessage", user, DateTime.Now.ToString(":yyyy/MM/dd HH:mm:ss"), message);
        }
    }
}
