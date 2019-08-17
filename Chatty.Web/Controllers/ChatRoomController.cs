using Chatty.Core.ChatRoom;
using Chatty.Core.User;
using Chatty.Web.Models;
using Chatty.Web.Models.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chatty.Web.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomManager chatRoomManager;
        private readonly IUserManager userManager;

        public ChatRoomController(IChatRoomManager chatRoomManager, IUserManager userManager)
        {
            this.chatRoomManager = chatRoomManager;
            this.userManager = userManager;
        }

        public async Task<ActionResult> Detail(string name)
        {
            await this.userManager.JoinRoomAsync();
            var messages = (await this.chatRoomManager.GetMessagesAsync(name))
                .Select(x => new MessageViewModel
                {
                    Message = x.Content,
                    UserId = x.UserId,
                    UserName = x.User.UserName,
                    Date = x.Date
                });

            return View(new ChatRoomDetailViewModel
            {
                Messages = messages,
                Name = name
            });
        }
    }
}