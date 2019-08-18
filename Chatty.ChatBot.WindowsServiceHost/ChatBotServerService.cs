using Chatty.ChatBot.Logic.Bots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.WindowsServiceHost
{
    public partial class ChatBotServerService : ServiceBase
    {
        IChatBotServer server;
        public ChatBotServerService()
        {
            InitializeComponent();
            this.server = new StockBotServer();
        }

        protected override void OnStart(string[] args)
        {
            this.server.Start();
        }

        protected override void OnStop()
        {
            this.server.Stop();
        }
    }
}
