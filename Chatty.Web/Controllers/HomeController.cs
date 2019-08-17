using Chatty.Core.ChatRoom;
using Chatty.Core.User;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Chatty.Web.Models.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chatty.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<ChatRoom> chatRoomRepository;

        public HomeController(IRepository<ChatRoom> chatRoomRepository)
        {
            this.chatRoomRepository = chatRoomRepository;
        }

        public ActionResult Index()
        {
            var chatRooms = this.chatRoomRepository.All()
                .Select(x => new ChatRoomListItemViewModel
                {
                    Name = x.Name,
                    NumberOfUsers = x.Users.Count()
                });

            return View(chatRooms);
        }
    }
}