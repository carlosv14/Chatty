using System.Threading.Tasks;

namespace Chatty.Core.ChatRoom
{
    public interface IChatRoomManager
    {
        Task<OperationResult> CreateAsync(string chatRoomName);
    }
}