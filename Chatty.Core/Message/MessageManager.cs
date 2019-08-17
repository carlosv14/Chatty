using Chatty.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Core.Message
{
    public class MessageManager
    {
        public MessageManager(IRepository<Chatty.Database.Models.Message> messageRepository)
        {
           
        }

        public async Task<OperationResult> Save(string message)
        {
            return new OperationResult();
        }
    }
}
