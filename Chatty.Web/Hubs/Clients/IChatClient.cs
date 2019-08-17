using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatty.Web.Hubs.Clients
{
    public interface IChatClient
    {
        void SendMessage(string message);
    }
}