using Microsoft.AspNetCore.SignalR;

//using Microsoft.AspNetCore.SignalR;

namespace Hosts
{
    public class MessageHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;

            Console.WriteLine($"User {userId} connected");
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string receiverId, string message)
        {
            await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
        }
    }
}
