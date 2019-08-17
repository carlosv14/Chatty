using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatty.Web.Models
{
    public class MessageViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}