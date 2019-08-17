using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chatty.Web.Hubs.Tickers
{
    public interface IChatTicker
    {
        Task SendMessage(string message);


    }
}