using Chatty.Core.Message;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Chatty.Web.Hubs.Clients;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace Chatty.Web.Hubs.Ticker
{
    public class ChatTicker : IChatTicker
    {
        private readonly IMessageManager messageManager;
        private readonly IHubContext<IChatClient> hubContext;
        private readonly IRepository<ApplicationUser> userRepository;

        public ChatTicker(
            IMessageManager messageManager,
            IHubContext<IChatClient> hubContext,
            IRepository<ApplicationUser> userRepository)
        {
            this.messageManager = messageManager;
            this.hubContext = hubContext;
            this.userRepository = userRepository;
        }
        public async Task SendMessage(string message)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            var currentUser = this.userRepository.Find(currentUserId);
            var date = DateTime.Now;
            var result = await this.messageManager.SaveMessageAsync(message, date, currentUserId);
            if (result.Succeeded)
            {
                this.hubContext.Clients.All.SendMessage($"[{date}] - {currentUser.UserName}: {message}");
            }
        }
    }
}