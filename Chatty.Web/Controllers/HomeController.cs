using Chatty.Core.ChatRoom;
using Chatty.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chatty.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserManager userManager;

        public HomeController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            await this.userManager.JoinRoomAsync();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}