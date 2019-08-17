using Chatty.ChatBot.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var chatBotServer = new StockBotServer();
            Console.WriteLine("Starting bot");
            chatBotServer.Start();
            Console.WriteLine("Awaiting commands");
            Console.ReadKey();
            Console.WriteLine("Stopping bot");
            chatBotServer.Stop();
        }
    }
}
