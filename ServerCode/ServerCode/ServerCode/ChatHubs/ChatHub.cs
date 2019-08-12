using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendToAll(string name, string message)
        {
           await Clients.All.SendAsync("sendToAll", name, message);
        }
    }
}
