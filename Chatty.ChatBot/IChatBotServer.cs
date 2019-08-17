using System.Threading.Tasks;

namespace Chatty.ChatBot
{
    public interface IChatBotServer
    {
        void Start();
        void Stop();
    }
}