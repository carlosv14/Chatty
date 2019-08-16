using Chatty.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Initializer
{
    class DropCreateChattyDatabaseAlways : DropCreateDatabaseAlways<ChattyContext>
    {
        protected override void Seed(ChattyContext context)
        {
            var task = Task.Run(async () => await ChattySeed.GenerateData(context));
            task.Wait();
        }
    }
}
