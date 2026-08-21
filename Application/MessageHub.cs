using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MessageHub:Hub
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
