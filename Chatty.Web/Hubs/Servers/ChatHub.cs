using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chatty.Web.Hubs.Clients;
using Chatty.Web.Hubs.Tickers;
using Microsoft.AspNet.SignalR;

namespace Chatty.Web.Hubs.Servers
{
    [Authorize]
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IChatTicker chatTicker;

        public ChatHub(IChatTicker chatTicker)
        {
            this.chatTicker = chatTicker;
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public async Task SendMessage(string message)
        {
            await this.chatTicker.SendMessage(message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            return base.OnDisconnected(stopCalled);
        }
    }
}