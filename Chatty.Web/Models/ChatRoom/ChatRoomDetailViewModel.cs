using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatty.Web.Models.ChatRoom
{
    public class ChatRoomDetailViewModel
    {
        public ChatRoomDetailViewModel()
        {
            this.Messages = new List<MessageViewModel>();
        }

        public string Name { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}