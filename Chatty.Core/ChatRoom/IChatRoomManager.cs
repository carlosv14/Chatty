using Chatty.Database.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatty.Core.ChatRoom
{
    public interface IChatRoomManager
    {
        Task<OperationResult> CreateAsync(string chatRoomName);

        Task<IEnumerable<Database.Models.Message>> GetMessagesAsync(string chatRoomName);
    }
}