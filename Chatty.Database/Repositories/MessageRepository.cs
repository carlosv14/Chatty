using Chatty.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Database.Repositories
{
    public class MessageRepository : ChattyBaseRepository<Message>
    {
        public MessageRepository(ChattyContext context) 
            : base(context)
        {
            this.Context = context;
        }

        public override IQueryable<Message> All()
        {
            return this.Context.Messages;
        }
    }
}
