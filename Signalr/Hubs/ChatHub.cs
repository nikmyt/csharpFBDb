using Microsoft.AspNetCore.SignalR;

namespace Signalr.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string user, string message)
        { 

            //return Task.CompletedTask;
            return Clients.All.SendAsync("RecieveMessage",user, message);
        }
    }
}
