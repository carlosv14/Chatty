using System.Threading.Tasks;

namespace Chatty.ChatBot.Logic.Bots
{
    public interface IChatBotServer
    {
        void Start();
        void Stop();
    }
}