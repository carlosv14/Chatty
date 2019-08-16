using Chatty.Core.Authentication;
using Chatty.Database.Models;
using Chatty.Database.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chatty.Core.ChatRoom
{
    public class ChatRoomManager : IChatRoomManager
    {
        private readonly IRepository<Database.Models.ChatRoom> chatRoomRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        public ChatRoomManager(IRepository<Database.Models.ChatRoom> chatRoomRepository, IRepository<ApplicationUser> userRepository)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.userRepository = userRepository;
        }

        public async Task<OperationResult> CreateAsync(string chatRoomName)
        {
            if (chatRoomName == string.Empty)
            {
                throw new ArgumentException("Name for a chatroom can't be empty");
            }

            var chatRoom = await this.chatRoomRepository.FindAsync(chatRoomName);
            if (chatRoom == null)
            {
                this.chatRoomRepository.Create(new Database.Models.ChatRoom
                {
                    Name = chatRoomName,
                });
            }

            await this.chatRoomRepository.SaveChangesAsync();
            return new OperationResult(true);
        }
    }
}
