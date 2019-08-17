using System.Threading.Tasks;

namespace Chatty.ChatBot.Bots
{
    public interface IChatBotServer
    {
        void Start();
        void Stop();
    }
}