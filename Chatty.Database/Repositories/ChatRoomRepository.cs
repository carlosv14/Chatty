using Chatty.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database.Repositories
{
    public class ChatRoomRepository : ChattyBaseRepository<ChatRoom>
    {
        public ChatRoomRepository(ChattyContext context) 
            : base(context)
        {
            this.Context = context;
        }

        public override IQueryable<ChatRoom> All()
        {
            return this.Context.ChatRooms;
        }
    }
}
