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
            var chatBotServer = new ChatBotServer();
            Console.WriteLine("Starting bot");
            chatBotServer.Start();
            Console.ReadKey();
            Console.WriteLine("Stopping bot");
            chatBotServer.Stop();
        }
    }
}
