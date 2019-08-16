using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chatty.Core.User
{
    public class UserManager : IUserManager
    {
        private const string DefaultRoom = "Default Room";

        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<Database.Models.ChatRoom> chatRoomRepository;

        public UserManager(IRepository<ApplicationUser> userRepository, IRepository<Database.Models.ChatRoom> chatRoomRepository)
        {
            this.userRepository = userRepository;
            this.chatRoomRepository = chatRoomRepository;
        }

        public async Task<OperationResult> JoinRoomAsync(string roomName = DefaultRoom)
        {
            var user = await this.userRepository.FindAsync(Thread.CurrentPrincipal.Identity.GetUserId());
            if (user == null)
            {
                return new OperationResult(new string[] { "User must be registered to enter a room" });
            }
            var room = await this.chatRoomRepository.FindAsync(roomName);
            if (room == null)
            {
                return new OperationResult(new string[] { "Room doesn't exist" });
            }
            if (room.Users.Any(x => x.Id == Thread.CurrentPrincipal.Identity.GetUserId()))
            {
                return new OperationResult(true);
            }
            user.ChatRooms.Add(room);
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
            return new OperationResult(true);
        }
    }
}
