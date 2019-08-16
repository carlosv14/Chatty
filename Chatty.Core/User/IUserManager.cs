using System.Threading.Tasks;

namespace Chatty.Core.User
{
    public interface IUserManager
    {
        Task<OperationResult> JoinRoomAsync(string roomName = "Default Room");
    }
}