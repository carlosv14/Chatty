using System;
using System.Threading.Tasks;

namespace Chatty.Core.Message
{
    public interface IMessageManager
    {
        Task<OperationResult> SaveMessageAsync(string messageText, DateTime date, string userId, string chatRoom = "Default Room");
    }
}