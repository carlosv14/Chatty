using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.Commands
{
    public class StockCommandResolver : ICommandResolver<string>
    {
        public async Task<string> ResolveAsync()
        {
            return "result";
        }
    }
}
