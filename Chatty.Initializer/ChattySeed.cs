using Chatty.Core.Authentication;
using Chatty.Core.ChatRoom;
using Chatty.Database;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Initializer
{
    public class ChattySeed
    {
        public static async Task GenerateData(ChattyContext context)
        {
            var chatRoomRepository = new ChatRoomRepository(context);
            chatRoomRepository.Create(new ChatRoom
            {
                Name = "Default Room",
            });

            await chatRoomRepository.SaveChangesAsync();
        }
    }
}
