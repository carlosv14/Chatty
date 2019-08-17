using Chatty.Database.Repositories;
using Chatty.Web.Hubs.Clients;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace Chatty.Web.Hubs.Ticker
{
    public class ChatTicker : IChatTicker
    {
        private readonly IRepository<Database.Models.Message> messageRepository;
        private readonly IHubContext<IChatClient> hubContext;

        public ChatTicker(IRepository<Database.Models.Message> messageRepository, IHubContext<IChatClient> hubContext)
        {
            this.messageRepository = messageRepository;
            this.hubContext = hubContext;
        }
        public async Task SendMessage(string message)
        {
            var messages = await this.messageRepository.All().ToListAsync();
            this.hubContext.Clients.All.SendMessage(message);
            throw new NotImplementedException();
        }
    }
}